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
            int index = 0;
            while (index < 7)
            {
                //.Next(int, int) limits the return to a non-negative random integer 
                //that is equal to or greater than the first int and less than the second the int.
                //Said another way, it is inclusive of the first int and
                //exclusive of the second int.
                uint r = (uint)rnd.Next(1, 40);
                if (!newRandoms.Contains(r)) //prevent duplicates
                {
                    newRandoms[index] = r;
                    index++;
                }
            }
            return newRandoms.OrderBy(x => x).ToArray();
        }
        private static uint[] GetUserInput()
        {
            uint[] inputs = new uint[7];
            int i = 0;
            while (i < 7)
            {
                Console.WriteLine("Enter a whole number between 1 and 39 inclusive. No duplicates, please.");
                //Note: input <= 39 would cause an error if the first part of the
                // if failed and we used & instead of && (And instead of AndAlso in vb.net).
                //The second part of the if never executes if the first part fails
                //when && is used.                                                             //prevents duplicates
                if (uint.TryParse(Console.ReadLine(), out uint input) && input <= 39 && input >0 && !inputs.Contains(input))
                {
                    inputs[i] = input;
                    i++; //Note: i is not incremented unless we have a successful entry
                }
                else
                    Console.WriteLine("Try again.");
            }
            return inputs.OrderBy(x => x).ToArray();
        }
        //I used a List<T> here because we don't know how many elements we will have.
        private static List<uint> GetMatches(uint[] input, uint[] rands)
        {
            List<uint> matches = new List<uint>();
            int i;
            for (i=0; i<7; i++)
            {
                if(rands.Contains(input[i]))
                    matches.Add(input[i]);
            }
            //Or skip the for loop and do as Sunny Pelletier answered
            //matches = input.Intersect(rands).ToList();
            return matches.OrderBy(x=>x).ToList();
        }
        //You are able to send both List<T> and arrays to this method because they both implement IEnumerable
        private static void PrintEnumerable(IEnumerable<uint> ToPrint)
        {
            foreach (uint item in ToPrint)
                Console.WriteLine(item);
        }
    }
