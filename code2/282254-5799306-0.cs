    public static string SkipReplace(this string input, string oldValue, string newValue)
    {
        if (input == null)
            throw new ArgumentNullException("input");
        if (string.IsNullOrEmpty(oldValue))
            throw new ArgumentException("oldValue");
        if (newValue == null)
            throw new ArgumentNullException("newValue");
        int index = input.IndexOf(oldValue);
        if (index > -1)
        {
            int startingPoint = index + oldValue.Length;
            int count = input.Length - startingPoint;
            StringBuilder builder = new StringBuilder(input);
            builder.Replace(oldValue, newValue, startingPoint, count);
            return builder.ToString();
        }
        return input;
    }
