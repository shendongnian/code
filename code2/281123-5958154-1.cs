    class Program
    {
        static void Main(string[] args)
        {
            string sourceString = @"<box><3>
    <table><1>
    <chair><8>";
            Regex ItemRegex = new Regex(@"<(?<item>\w+?)><(?<count>\d+?)>", RegexOptions.Compiled);
            foreach (Match ItemMatch in ItemRegex.Matches(sourceString))
            {
                Console.WriteLine(ItemMatch);
            }
            Console.ReadLine();
        }
    }
    
