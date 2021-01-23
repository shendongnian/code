    public static class StringExtensions
    {
        public static string Repeat(this string input, int count)
        {
            StringBuilder builder = new StringBuilder();
    
            for(int i = 0; i < count; i++) builder.Append(input);
    
            return builder.ToString();
        }
    }
