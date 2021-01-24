        static void Main(string[] args)
        {
            string input = "Alarm Level 1 (D1) [Low (-15.7)]";
            string pattern = @"\[\w+\s\([\d.-]+\)\]";
            string outputA = Regex.Match(input, pattern).Value;
            string outputB = Regex.Match(outputA, @"[\d.-]+").Value;
            Console.WriteLine("A: " + outputA);
            Console.WriteLine("B: " + outputB);
            Double intOutput = Convert.ToDouble(outputB);
            Console.ReadLine();
        }
