    public object TrimString(string input, int length)
        {
            // return nothing if the string is null
            if (String.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            // invalid length submitted
            if (length <= 0)
            {
                length = 100;
            }
            if (input.Length > length)
            {
                return input.Substring(0, length) + "...";
            }
            return input;
        }
