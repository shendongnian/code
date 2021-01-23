    using System;
    using System.Text.RegularExpressions;
    class Program
    {
        private static Regex regexObj = 
            new Regex(@"^\s*public\s+\w+\s+(\w+)\(.*?\)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        static void Main(string[] args)
        {
            var testSubject = 
                "public object QuestionTextExists(QuestionBankProfileHandler QBPH)";
            var result = regexObj.Match(testSubject).Groups[1].Value;
            
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
