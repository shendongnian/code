    public static class MyExtensions
    {
        public static string Join(this List<int> a, string splitChar)
        {
            return string.Join(splitChar, a.Select(n => n.ToString()).ToArray());
        }
    }
