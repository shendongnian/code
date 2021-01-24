    static void Main(string[] args)
        {
            double value1;
            int round1;
            while (true)
            {
                Console.Write("Enter a decimal-number: ");
                string StrValue = Console.ReadLine();
                bool success = Double.TryParse(StrValue, out value1);
                while (!success)
                {
                     Console.WriteLine("You need to use (,) as decimal-sign according to Swedish standard!"); //From here I want a loop if . is used instead of ,
                     StrValue = Console.ReadLine();
                     success = Double.TryParse(StrValue, out value1);
                }
                Console.Write("With how many decimal-numbers do you want to round it down to?: ");
                string StrRound = Console.ReadLine();
                bool success1 = Int32.TryParse(StrRound, out round1);
                if (!success1)
                {
                    Console.WriteLine("Only use whole numbers when rounding");
                }
                else break;
            }
        }
    }
