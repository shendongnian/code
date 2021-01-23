            static void Main(string[] args)
        {
            
            CalculateRomanNumerals(1674);
        }
        private static void CalculateRomanNumerals(int integerInput)
        {
            foreach (var item in Enum.GetValues(typeof(RomanNumerals)).Cast<int>().Reverse())
            {
                integerInput = ProcessNumber(integerInput, item);
            }
            Console.ReadKey();
        }
        private static int ProcessNumber(int input, int number)
        {
            while (input >= number)
            {
                input -= number;
                Console.Write((RomanNumerals)number);
            }
            return input;
        }
        enum RomanNumerals : int
        {
            I = 1,
            IV = 4,
            V = 5,
            IX = 9,
            X = 10,
            L = 50,
            XC = 90,
            C = 100,
            CD = 400,
            D = 500,
            CM = 900,
            M = 1000
        }
