    public static class MyStringExtensions{
        public static string Sanitize(this string input)
        {
            if(input == null) throw new ArgumentNullException("input");
            var trimmed = input.Trim();
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(trimmed);
        }
    }
