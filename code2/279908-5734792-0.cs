    public class Program
    {
        public class SomeClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        static void Main(string[] args)
        {
            List<SomeClass> sample = new List<SomeClass>
            {
                new SomeClass { Id = 4, Name = "ABC" },
                new SomeClass { Id = 1, Name = "XYZ" },
                new SomeClass { Id = 2, Name = "JKL" }
            };
            var result = sample.OrderByDynamic("Name", OrderDirection.Ascending).ToList();
            result.ForEach(x => Console.WriteLine("Id: " + x.Id + " | Name: " + x.Name));
            Console.ReadKey();
        }
    }
    public enum OrderDirection
    {
        Ascending,
        Descending
    }
    public static class LinqExtensions
    {
        public static IEnumerable<T> OrderByDynamic<T>(this IEnumerable<T> source, string propertyName, OrderDirection direction = OrderDirection.Ascending)
        {
            if(direction == OrderDirection.Ascending)
                return source.OrderBy(x => x.GetType().GetProperty(propertyName).GetValue(x, null));
            else
                return source.OrderByDescending(x => x.GetType().GetProperty(propertyName).GetValue(x, null));
        }
    }
