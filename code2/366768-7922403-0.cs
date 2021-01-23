    public static class MyExtensions
    {
        public static bool ContainsAnySequenceOf(this String str, List<char> charArray)
        {
            foreach (char c in charArray)
            {
                if (str.ToCharArray().Any(x => x == c))
                {
                    charArray.Remove(c);
                    return str.Substring(str.IndexOf(c), Math.Min(str.Length - str.IndexOf(c), charArray.Count)).ContainsAnySequenceOf(charArray);
                }
            }
            return false;
        }
    }
