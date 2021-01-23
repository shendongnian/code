    public static class ExtensionMethods
    {
        static char[] SpecialCharacters = new char[] { ',', '"', '\r', '\n' };
        public static string ToWrap(this string val)
        {
            StringBuilder builder = new StringBuilder();
            bool firstColumn = true;
            // Add separator if this isn't the first value
            if (!firstColumn)
                builder.Append(',');
            // Implement special handling for values that contain comma or quote
            // Enclose in quotes and double up any double quotes
            if (val.IndexOfAny(SpecialCharacters) != -1)
                builder.AppendFormat("\"{0}\"", val.Replace("\"", "\"\""));
            else
                builder.Append(val);
            firstColumn = false;
            return builder.ToString();
        }
    }
