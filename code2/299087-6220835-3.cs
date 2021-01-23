    public static class ObjectExtensions
    {
        public static string ReplaceSet(this string text, string set, string x)
        {
            for (int i = 0; i < set.Length; i++)
            {
                text = text.Replace(set[i].ToString(), x);
            }
            return text;
        }
        public static string RemoveSet(this string text, string set)
        {
            return text.ReplaceSet(set, "");
        }
    }
