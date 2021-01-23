    class Program
    {
        static void Main()
        {
            string input = "hello WoRlD";
            string result = Regex.Replace(input, "world", "csharp", RegexOptions.IgnoreCase);
            Console.WriteLine(result); // prints "hello csharp"
        }
    }
