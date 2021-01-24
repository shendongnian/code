        public static Expression<Func<T, IEnumerable<byte>>> GetSerializer<T>(Expression<Func<T, int>> expr)
        {
            // Find GetBytes method which accepts int as an argument
            var method = typeof(BitConverter).GetMethod("GetBytes", BindingFlags.Static | BindingFlags.Public, null,
                CallingConventions.Any, new[] {typeof(int)}, null);
            // Input parameter for lambda -> (T p)
            var p = Expression.Parameter(typeof(T));
            
            // Body of lambda -> BitConverter.GetBytes(expr(p))
            var body = Expression.Call(method, Expression.Invoke(expr, p));
            // Build lambda -> (T p) => BitConverter.GetBytes(expr(p))
            return Expression.Lambda<Func<T, IEnumerable<byte>>>(body, p);
        }
