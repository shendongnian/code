    using System.Text;
    public static class StringExtensions
    {
        public static string ReplaceAll(this string original, string toBeReplaced, string newValue)
        {
            if (string.IsNullOrEmpty(original) || string.IsNullOrEmpty(toBeReplaced)) return original;
            if (newValue == null) newValue = string.Empty;
            StringBuilder sb = new StringBuilder();
            foreach (char ch in original)
            {
                if (toBeReplaced.IndexOf(ch) < 0) sb.Append(ch);
                else sb.Append(newValue);
            }
            return sb.ToString();
        }
    
        public static string ReplaceAll(this string original, string[] toBeReplaced, string newValue)
        {
            if (string.IsNullOrEmpty(original) || toBeReplaced == null || toBeReplaced.Length <= 0) return original;
            if (newValue == null) newValue = string.Empty;
            foreach (string str in toBeReplaced)
                if (!string.IsNullOrEmpty(str))
                    original = original.Replace(str, newValue);
            return original;
        }
    }
