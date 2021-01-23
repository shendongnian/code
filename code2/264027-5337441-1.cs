        public static string Encrypt(string inputString, int shiftPattern)
        {
            StringBuilder sb = new StringBuilder();
            foreach(char letter in inputString.ToLower())
            {
                int encryptedValue = 0;
                if (letter == ' ')
                {
                    encryptedValue = ' ';
                }
                else
                {
                    encryptedValue = (((letter - 'a') + shiftPattern) % 26) + 'a';
                }
                
                sb.Append((char)encryptedValue);
            }
            return sb.ToString();
        }
