        public static char FirstNonRepeatedChar(string input)
        {
            bool isDuplicate;
            for (int i = 0; i < input.Length; i++)
            {
                 isDuplicate = false;
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] == input[j])
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
