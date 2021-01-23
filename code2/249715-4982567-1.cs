    static class Program
    {
        static void Main()
        {
            var list = new List<string> { {"a"}, {"b"}, {"c"} };
            string str = list.ToStringExtended();
        }
    }
    public static class ListHelper
    {
        public static string ToStringExtended(this IList<String> list)
        {
            return string.Join(", ", list.ToArray());
        }
    }
