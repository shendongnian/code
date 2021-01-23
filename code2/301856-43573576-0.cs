    public static string ReplaceIgnoreCase(this string source, string oldVale, string newVale)
        {
            if (source.IsNullOrEmpty() || oldVale.IsNullOrEmpty())
                return source;
            var stringBuilder = new StringBuilder();
            string result = source;
            int index = result.IndexOf(oldVale, StringComparison.InvariantCultureIgnoreCase);
            while (index >= 0)
            {
                if (index > 0)
                    stringBuilder.Append(result.Substring(0, index));
             
                if (newVale.IsNullOrEmpty().IsNot())
                    stringBuilder.Append(newVale);
                stringBuilder.Append(result.Substring(index + oldVale.Length));
                result = stringBuilder.ToString();
                index = result.IndexOf(oldVale, StringComparison.InvariantCultureIgnoreCase);
            }
            return result;
        }
