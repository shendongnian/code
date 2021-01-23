    public class PasswordGenerator
    {
        private const string AlphaUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string AlphaLower = "abcdefghijklmnopqrstuvwxyz";
        private const string Numeric = "1234567890";
        private const string Special = "@#$?!";
        private const string AllChars = AlphaUpper + AlphaLower + Numeric + Special;
    
        private readonly MersenneTwister _random = new MersenneTwister();
    
        /// <summary>
        /// Generates a strong password out of upper case, lower case, numeric and special characters.
        /// </summary>
        /// <param name="length">The length of the password to generate. Must be at least 4.</param>
        /// <returns>A random strong password.</returns>
        public string Generate(int length)
        {
            string password = string.Empty;
    
            // generate four repeating random numbers for lower, upper, numeric and special characters
            // by filling these positions with corresponding characters, we can ensure the password has
            // at least one character of each type
            string posArray = "0123456789";
    
            if (length < posArray.Length)
                posArray = posArray.Substring(0, length);
    
            int pLower = GetRandomPosition(ref posArray);
            int pUpper = GetRandomPosition(ref posArray);
            int pNumber = GetRandomPosition(ref posArray);
            int pSpecial = GetRandomPosition(ref posArray);
    
            for (int i = 0; i < length; i++)
            {
                if (i == pLower)
                {
                    password += GetRandomChar(AlphaUpper);
                }
                else if (i == pUpper)
                {
                    password += GetRandomChar(AlphaLower);
                }
                else if (i == pNumber)
                {
                    password += GetRandomChar(Numeric);
                }
                else if (i == pSpecial)
                {
                    password += GetRandomChar(Special);
                }
                else
                {
                    password += GetRandomChar(AllChars);
                }
            }
    
            return password;
        }
    
        private string GetRandomChar(string fullString)
        {
            return fullString.ToCharArray()[(int)Math.Floor(_random.NextDouble() * fullString.Length)].ToString();
        }
    
        private int GetRandomPosition(ref string posArray)
        {
            string randomChar = posArray.ToCharArray()[(int)Math.Floor(_random.NextDouble() * posArray.Length)].ToString();
            int pos = int.Parse(randomChar);
            posArray = posArray.Replace(randomChar, string.Empty);
    
            return pos;
        }
    }
