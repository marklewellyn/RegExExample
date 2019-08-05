using System;
using System.Text.RegularExpressions;

namespace RegExExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"(?<dateString>(?<year>[12]\d{3})[-/](?<month>[01]\d|2[0-3])[-/](?<day>[012]\d|3[01])" + 
                @"T(?<hour>[01]\d|2[0-3]):(?<minute>[0-5]\d):(?<second>[0-5]\d)Z|" + 
                @"(?<year>[12]\d{3})[-/](?<month>[01]\d|2[0-3])[-/](?<day>[012]\d|3[01]))");
            string date1 = "2014-08-18T13:03:25Z";
            string date2 = "2014/08/18T13:03:25Z";
            string date3 = "2014-08-18";
            string date4 = "2014/08/18";

            DateParse(date1, pattern);
            DateParse(date2, pattern);
            DateParse(date3, pattern);
            DateParse(date4, pattern);

            Console.ReadKey();
        }

        private static void DateParse(string date, Regex pattern)
        {
            Match data = pattern.Match(date);
            if (data.Success)
            {
                Console.WriteLine("-----------------------------------------------------");
                if (data.Groups["dateString"].Length > 0) Console.WriteLine($"The date is: {data.Groups["dateString"].Value}");
                if (data.Groups["year"].Length > 0) Console.WriteLine($"The year is: {data.Groups["year"].Value}");
                if (data.Groups["month"].Length > 0) Console.WriteLine($"The month is: {data.Groups["month"].Value}");
                if (data.Groups["day"].Length > 0) Console.WriteLine($"The day is: {data.Groups["day"].Value}");
                if (data.Groups["hour"].Length > 0) Console.WriteLine($"The hour is: {data.Groups["hour"].Value}");
                if (data.Groups["minute"].Length > 0) Console.WriteLine($"The minute is: {data.Groups["minute"].Value}");
                if (data.Groups["second"].Length > 0) Console.WriteLine($"The second is: {data.Groups["second"].Value}");
            }
        }
    }
}
