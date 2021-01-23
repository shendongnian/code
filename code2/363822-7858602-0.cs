    class Program
    {
        static void Main(string[] args)
        {
            var people = new[]{
                new Person { Name = "David", Age = 40 },
                new Person { Name = "Maria", Age = 12 },
                new Person { Name = "Lucas", Age = 45 }
            }.AsQueryable();
            foreach (var p in people.OrderBy("Age"))
            {
                Console.Write(p.Name);
            }
        }
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
    static class IQueryableExtensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> items, string propertyName)
        {
            var typeOfT = typeof(T);
            var parameter = Expression.Parameter(typeOfT, "parameter");
            var propertyType = typeOfT.GetProperty(propertyName).PropertyType;
            var propertyAccess = Expression.PropertyOrField(parameter, propertyName);
            var orderExpression = Expression.Lambda(propertyAccess, parameter);
            var expression = Expression.Call(typeof(Queryable), "OrderBy", new Type[] { typeOfT, propertyType }, items.Expression, Expression.Quote(orderExpression));
            return items.Provider.CreateQuery<T>(expression);
        }        
    }
