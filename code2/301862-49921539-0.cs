    public static class ExtensionMethodsString
    {
        public static string Replace(this String thisString, string oldValue, string newValue, StringComparison stringComparison)
        {
            string working = thisString;
            int index = working.IndexOf(oldValue, stringComparison);
            while (index != -1)
            {
                working = working.Remove(index, oldValue.Length);
                working = working.Insert(index, newValue);
                index = index + newValue.Length;
                index = working.IndexOf(oldValue, index, stringComparison);
            }
            return working;
        }
    }
