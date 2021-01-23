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
                    encryptedValue = (((letter - 97) + shiftPattern) % 26) + 97;
                }
                
                sb.Append((char)encryptedValue);
            }
            return sb.ToString();
        }
