    public static string ReplaceIgnoreCase(this string source, string oldVale, 
    string newVale)
        {
            if (source.IsNullOrEmpty() || oldVale.IsNullOrEmpty())
                return source;
            var stringBuilder = new StringBuilder();
            string result = source;
            int index = result.IndexOf(oldVale, StringComparison.InvariantCultureIgnoreCase);
            bool initialRun = true;
            while (index >= 0)
            {
                string substr = result.Substring(0, index);
                substr = substr + newVale;
                result = result.Remove(0, index);
                result = result.Remove(0, oldVale.Length);
                stringBuilder.Append(substr);
                index = result.IndexOf(oldVale, StringComparison.InvariantCultureIgnoreCase);
            }
            if (result.Length > 0)
            {
                stringBuilder.Append(result);
            }
            
            return stringBuilder.ToString();
        }
