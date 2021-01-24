        static void Main(string[] args)
        {
            int sum = GetValue("1A2B3C4D5DC");
            // {1,2,3,4,5} = 10*(1+2*2+3*3+4*4+5*5) = 550
        }
        public static int GetValue(string input)
        {
            // make input all lowercase
            input = input.ToLower();
            // replace terminator dc with next letter to
            // avoid failing the search;
            input = input.Replace("dc", "e");
            
            // initialize all unit values to zero
            const string tokens = "abcde";
            int[] units = new int[tokens.Length];
            // keep track of position of last parsed number
            int start = 0;
            for (int index = 0; index < tokens.Length; index++)
            {
                // fetch next letter
                char token = tokens[index];
                // find letter in input
                int position = input.IndexOf(token, start);
                // if found
                if (position>start)
                {
                    // extract string before letter
                    string temp = input.Substring(start, position-start);
                    // and convert to integer
                    int.TryParse(temp, out units[index]);
                }
                // update last parsed number
                start = position+1;
            }
            // add unit values, each one worth +10 more than the
            // previous one. 
            //
            // {x,y,z} = 10*x + 20*y + 30*z
            int sum = 0;
            for (int i = 0; i < units.Length; i++)
            {
                sum += 10*(i+1)*units[i];
            }
            return sum;
        }
    }
