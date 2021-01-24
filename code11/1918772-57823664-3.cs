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
            // Hardcoded
            var sumExpression1 = (Expression<Func<Data, Int32>>)(d => d.Value1); 
            // Generate property expression
            var sumExpression2 = GeneratePropertyExpression<Data>("Value2"); 
            // Generate Sum expression
            var sumExpression3 = GenerateSumExpression<DataContainer, Data>("Value3"); 
            var selected = list.Select(c => new
            {
                Sum1 = c.Data.Sum(sumExpression1),
                Sum2 = c.Data.Sum(sumExpression2),
                // will not need the compile() if you generate the entire select expression.
                Sum3 = sumExpression3.Compile()(c)  
            }); ;
            var first = selected.First();
            var last = selected.Last();
            Console.WriteLine($"First().Sum1 = {first.Sum1}"); // 2
            Console.WriteLine($"Last().Sum2 = {last.Sum2}");   // 6
            Console.WriteLine($"Last().Sum3 = {last.Sum3}");   // 9 
        }
        private static Expression<Func<TParent, Int32>> GenerateSumExpression<TParent, TChild>(String field)
        {
            var parameter = Expression.Parameter(typeof(TParent), "c");
            // I don't know a cleaner way to get the LINQ methods than this. 
            // We use Enumerable because it wants a concrete type.
            var sumMethod =
            (
                from m in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                where m.Name == "Sum"
                let p = m.GetParameters()
                where p.Length == 2
                    && p[0].ParameterType.IsGenericType
                    && p[0].ParameterType.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                    && p[1].ParameterType.IsGenericType
                    && p[1].ParameterType.GetGenericTypeDefinition() == typeof(Func<,>)
                select m
            ).FirstOrDefault()
             .MakeGenericMethod(typeof(TChild)); // Enumerable is not generic, so we'll make it a generic with this reflection method. 
            var nestedLambda = GeneratePropertyExpression<TChild>(field);
            // 'parameter' is our DataContainer object, while 'Data' is the
            // property we want. 
            var prop = Expression.PropertyOrField(parameter, "Data");
            // Null is the first parameter because it's a static extension method.
            var body = Expression.Call(null, sumMethod, prop, nestedLambda);
            return Expression.Lambda<Func<TParent, Int32>>(body, parameter);
        }
        private static Expression<Func<T, Int32>> GeneratePropertyExpression<T>(String field)
        {
            var parameter = Expression.Parameter(typeof(T), "d");
            var body = Expression.PropertyOrField(parameter, field);
            return Expression.Lambda<Func<T, Int32>>(body, parameter);
        }
        public static IQueryable<DataContainer> MakeList()
        {
            return new List<DataContainer>()
            {
                new DataContainer()
                {
                    Data = new List<Data>()
                    {
                        new Data() { Value1 = 1, Value2 = 2, Value3 = 3 },
                        new Data() { Value1 = 1, Value2 = 2, Value3 = 3 }
                    }.AsQueryable()
                },
                new DataContainer()
                {
                    Data = new List<Data>()
                    {
                        new Data() { Value1 = 1, Value2 = 2, Value3 = 3  },
                        new Data() { Value1 = 1, Value2 = 2, Value3 = 3  },
                        new Data() { Value1 = 1, Value2 = 2, Value3 = 3  }
                    }.AsQueryable()
                }
            }.AsQueryable();
        }
