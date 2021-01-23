    public static class Copier<T>
    {
        private static readonly Action<T, T> _copier;
    
        static Copier()
        {
            var x = Expression.Parameter(typeof(T), "x");
            var y = Expression.Parameter(typeof(T), "y");
            var expressions = new List<Expression>();
            foreach (var property in typeof(T).GetProperties())
            {
                if (property.CanWrite)
                {
                    var xProp = Expression.Property(x, property);
                    var yProp = Expression.Property(y, property);
                    expressions.Add(Expression.Assign(yProp, xProp));
                }
            }
            var block = Expression.Block(expressions);
            var lambda = Expression.Lambda<Action<T, T>>(block, x, y);
            _copier = lambda.Compile();
        }
    
        public static void CopyTo(T from, T to)
        {
            _copier(from, to);
        }
    }
