    internal class Program
        {
            private static void Main(string[] args)
            {
                var one = new List<string> {"Adam", "John"};
    
                var two = new List<string> {"Adam", "Houldsworth"};
    
                one.AddOrUpdate(two);
    
                Console.Read();
            }
        }
    
        static class Extensions
        {
            public static void AddOrUpdate(this IList<string> collection, IEnumerable<string> items)
            {
                foreach (var item in items.ToList())
                    collection.AddOrUpdate2(item);
            }
    
            public static void AddOrUpdate2(this IList<string> collection, string item)
            {
                if (collection.Any(c => c == item))
                    collection.Remove(collection.First(c => c == item));
    
                collection.Add(item);
            }
        }
