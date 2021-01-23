    public class Entity
    {
        public Entity(string someField)
        {
            SomeField = someField;
        }
    
        public string SomeField { get; set;  }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var entities = new[] {new Entity("fooBar"), new Entity("barBaz"), new Entity("baz"), new Entity("foo")};
            entities.Where(BuildExpression("ar","az").Compile())
                    .ToList()
                    .ForEach(e => Console.WriteLine(e.SomeField));
            Console.ReadLine();
        }
    
        public static Expression<Func<Entity, bool>> BuildExpression(params string[] words)
        {
            var parameter = Expression.Parameter(typeof (Entity));
    
            var matchs = words.Select(word =>
                                            {
                                                var property = Expression.Property(parameter, "SomeField");
                                                var toLower = Expression.Call(property, "ToLower", new Type[] {});
                                                var contains = Expression.Call(toLower, "Contains",
                                                                                new Type[]{},
                                                                                Expression.Constant(word));
                                                return contains;
                                            }).OfType<Expression>();
    
            var body = matchs.Aggregate(Expression.Or);
    
            return Expression.Lambda<Func<Entity, bool>>(body, new[] {parameter});
        } 
    }
