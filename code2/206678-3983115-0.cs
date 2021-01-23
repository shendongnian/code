    class Program
    {
        static void Main(string[] args)
        {
            // The pattern has been broken down for educational purposes
            string regexPattern =
                // Match any float, negative or positive, group it
                @"([-+]?\d+\.?\d*|[-+]?\d*\.?\d+)" +
                // ... possibly following that with whitespace
                @"\s*" +
                // ... followed by a plus
                @"\+" +
                // and possibly more whitespace:
                @"\s*" +
                // Match any other float, and save it
                @"([-+]?\d+\.?\d*|[-+]?\d*\.?\d+)" +
                // ... followed by 'i'
                @"i";
            Regex regex = new Regex(regexPattern);
            
            Console.WriteLine("Regex used: " + regex);
            while (true)
            {
                Console.WriteLine("Write a number: ");
                string imgNumber = Console.ReadLine();
                Match match = regex.Match(imgNumber);
                double real = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
                double img = double.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
                Console.WriteLine("RealPart={0};Imaginary part={1}", real, img);
            }                       
        }
    }
