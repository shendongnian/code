    class Program
    {
        private static Random rnd = new Random();
        static void Main(string[] args)
        {
            do
            {
                uint[] myRandoms = GetRandoms();
                uint[] userInput = GetUserInput();
                List<uint> matches = GetMatches(userInput, myRandoms);
                Console.WriteLine("Your Numbers");
                PrintEnumerable(userInput);
                Console.WriteLine("The Lottery Winners");
                PrintEnumerable(myRandoms);
                Console.WriteLine("Numbers You Matched");
                PrintEnumerable(matches);
                int NumOfMatches = matches.Count;
                if (matches.Count >= 4)
                    Console.WriteLine($"You win! You matched {NumOfMatches} numbers.");
                else
                    Console.WriteLine($"Sorry, you only matched {NumOfMatches} numbers.");
                Console.WriteLine("Play again? Enter Y for yes and N for no.");
            } while (Console.ReadLine().ToUpper() == "Y");
        }
       private static uint[] GetRandoms()
        {
            uint[] newRandoms = new uint[7];
            int index;
            for (index=0; index<6; index++)
            {
                //.Next(int) limits the return to a non-negative random integer that is less than the int.
                newRandoms[index] = (uint)rnd.Next(101);
            }
            return newRandoms;
        }
        private static uint[] GetUserInput()
        {
            uint[] inputs = new uint[7];
            int i =0;
            uint input;
            while (i < 7)
            {
                Console.WriteLine("Enter a whole number between 0 and 100 inclusive.");
                //Note: input <= 100 would cause an error if the first part of the
                // if failed and we used & instead of && (And instead of AndAlso in vb.net).
                //The second part of the if never executes if the first part fails
                //when && is used.
                if (uint.TryParse(Console.ReadLine(), out input) && input <= 100)
                {
                    inputs[i] = input;
                    i++; //Note: i is not incremented unless we have a successful entry
                }
                else
                    Console.WriteLine("Try again.");
            }
            return inputs;
        }
        private static List<uint> GetMatches(uint[] input, uint[] rands)
        {
            List<uint> matches = new List<uint>();
            int i;
            for (i=0; i<7; i++)
            {
                if(rands.Contains(input[i]))
                    matches.Add(input[i]);
            }
            return matches;
        }
        //You are able to send both List<T> and arrays to this method because they both implement IEnumerable<T>
        private static void PrintEnumerable(IEnumerable<uint> ToPrint)
        {
            foreach (uint item in ToPrint)
                Console.WriteLine(item);
        }
    }
