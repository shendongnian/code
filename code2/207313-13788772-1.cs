        public static char FirstNonRepeatedChar(string input)
        {
            bool isDuplicate;
            for (int i = 0; i < input.Length; i++)
            {
                 isDuplicate = false;
                for (int j = 0; j < input.Length; j++)
                {
                    if ((input[i] == input[j]) && i !=j )
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if (!isDuplicate)
                {
                    return input[i];
                }
            }
            return default(char);
        }
