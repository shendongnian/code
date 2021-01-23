    public static class StringHelper
    {
        public static string ToString(this string input , int maxLength , char paddingChar = ' ', bool isPaddingLeft = true)
        {
            if (string.IsNullOrEmpty(input))
                return new string('-', maxLength);
            else if (input.Length > maxLength)
                return input.Substring(0, maxLength);
            else
            {
                int padAmount = maxLength - input.Length;
                if (isPaddingLeft)
                    return input + new string(paddingChar, padAmount);
                else
                    return new string(paddingChar, padAmount) + input;
            }
        }
    }
