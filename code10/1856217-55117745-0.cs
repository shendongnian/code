        static int readInt(int low, int high)
        {
            int result;
            bool success;
            bool outOfLimits = false;
            do
            {
                Console.Write("Enter a number: ");
                string intString = Console.ReadLine();
                success = Int32.TryParse(intString, out result);
                if (!success)
                {
                    Console.WriteLine("{0} is not a valid number.", intString, low, high);
                    continue;
                }
                outOfLimits = result < low || result > high;
                if (outOfLimits)
                    Console.WriteLine("The string was NOT a number between {1} and {2}.", intString, low, high);
                else
                    Console.WriteLine("The string was a number within the limits, {0}.", intString);
            } while (!success || outOfLimits);
            return result;
        }
