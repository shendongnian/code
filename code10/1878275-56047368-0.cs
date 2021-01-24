    public class Data
    {
        public int Id { get; set; }
        public int Property { get; set; }
    }
   
    public class Program
    {
        private static void Main()
        {
            var allData = new List<Data>
            {
                new Data {Id = 1, Property = 1},
                new Data {Id = 2, Property = 1},
                new Data {Id = 3, Property = 2},
            };
            var values = new[] {1, 2};
            var results = values
                .Select(value => 
                    new {Value = value, Count = allData.Count(item => item.Property == value)});
            foreach (var result in results)
            {
                Console.WriteLine($"Value {result.Value} is contained in {result.Count} items");
            }
        }
    }
