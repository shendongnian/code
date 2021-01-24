        static void Main(string[] args)
        {
            var items = new[] { 1, 2, 3, 4, 5 }.AsQueryable();
            //for example, revert entire list
            var newOrder = new Dictionary<int, int>() { { 1, 5 }, { 2, 4 }, { 3, 3 }, { 4, 2 }, { 5, 1 } };
            var sorted = items.OrderBy(newOrder.ToSwithExpression())).ToList();
            foreach(var i in sorted)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
        static Expression<Func<T, K>> ToSwithExpression<T, K>(this Dictionary<T, K> dict, K defaultValue = default(K))
        {
            var paramm = Expression.Parameter(typeof(T), "x");
            //If nothing maps - use default value.
            Expression iter = Expression.Constant(defaultValue);
            foreach (var kv in dict)
            {
                iter = Expression.Condition(Expression.Equal(paramm, Expression.Constant(kv.Key)), Expression.Constant(kv.Value, typeof(K)), iter);
            }
            return Expression.Lambda<Func<T, K>>(Expression.Convert(iter, typeof(K)), paramm);
        }
