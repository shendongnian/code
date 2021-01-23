        static public string RemoveAny(this string s, string charsToRemove)
        {
            var result = "";
            foreach (var c in s)
                if (charsToRemove.Contains(c))
                    continue;
                else
                    result += c;
            return result;
        }
