    public class Data
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
    }
    public class DataContainer
    {
        public IQueryable<Data> Data { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list = MakeList();
            var sumExpression1 = (Expression<Func<Data, Int32>>)(l => l.Value1);
            var sumExpression2 = (Expression<Func<Data, Int32>>)(l => l.Value2);
            var selected = list.Select(c => new
            {
                Sum1 = c.Data.Sum(sumExpression1),
                Sum2 = c.Data.Sum(sumExpression2)
            });
            var first = selected.First();
            var last = selected.Last();
            Console.WriteLine($"First().Sum1 = {first.Sum1}"); // Returns 2
            Console.WriteLine($"Last().Sum2 = {last.Sum2}");   // Returns 6
        }
        public static IQueryable<DataContainer> MakeList()
        {
            return new List<DataContainer>()
            {
                new DataContainer()
                {
                    Data = new List<Data>()
                    {
                        new Data() { Value1 = 1, Value2 = 2 },
                        new Data() { Value1 = 1, Value2 = 2 }
                    }.AsQueryable()
                },
                new DataContainer()
                {
                    Data = new List<Data>()
                    {
                        new Data() { Value1 = 1, Value2 = 2 },
                        new Data() { Value1 = 1, Value2 = 2 },
                        new Data() { Value1 = 1, Value2 = 2 }
                    }.AsQueryable()
                }
            }.AsQueryable();
        }
    }
