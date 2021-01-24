        public static Expression<Func<T, IEnumerable<byte>>> GetSerializer<T, T2>(Expression<Func<T, T2>> expr)
            where T2 : struct
        {
            // Find GetBytes method which accepts T2 as an argument
            var method = typeof(BitConverter).GetMethod("GetBytes", BindingFlags.Static | BindingFlags.Public, null,
                CallingConventions.Any, new[] {typeof(T2)}, null);
            // Check if method exists
            if (method == null)
            {
                throw new ArgumentException("Invalid type provided");
            }
            // Input parameter for lambda -> (T p)
            var p = Expression.Parameter(typeof(T));
            
            // Body of lambda -> BitConverter.GetBytes(expr(p))
            var body = Expression.Call(method, Expression.Invoke(expr, p));
            // Build lambda -> (T p) => BitConverter.GetBytes(expr(p))
            return Expression.Lambda<Func<T, IEnumerable<byte>>>(body, p);
        }
