       static int readInt(string prompt, int low, int high) // METHOD readInt 
        {
            bool valid = false;
            int result = 0;
            while (!valid)
            {
                var intString = readString(prompt);
                valid = checkIfValid(intString, low, high, out result);
            }
            return result;
        }
    
        static bool checkIfValid(string s, int low, int high, out int result)
        {
            if (!Int32.TryParse(s, out result))
            {
                Console.WriteLine(s + " isn't an integer");
                return false;
            }
    
            if (result < low)
            {
                Console.WriteLine("Number is too low");
                return false;
            }
    
            if (result > high)
            {
                Console.WriteLine("Number is too high");
                return false;
            }
    
            return true;
        }
