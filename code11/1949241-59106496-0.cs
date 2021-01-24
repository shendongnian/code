    class Program
    {
        static void Main(string[] args)
        {
            List<object> items = new List<object>() {
                "pizza",
                1,
                4,
                10,
                "banana"
            };
            object[] filteredItems = RemoveStrings(items).ToArray();
            foreach(object item in filteredItems)
            {
                Console.WriteLine(item);
            }
        }
        public static IEnumerable<object> RemoveStrings(IEnumerable<object> items)
        {
            return items.Where(x => (x is string) == false);
        }
    }
