c#
        public static Expression<Func<T,bool>> ContainsString<T>(string value)
        {
            var constValue = Expression.Constant(value);
            var parameter = Expression.Parameter(typeof(T), "p");
            return Expression.Lambda<Func<T, bool>>(
                typeof(T).GetProperties()
                    .Where(p => p.PropertyType == typeof(string))
                    .Select(p => (Expression)Expression.Call(
                        Expression.Property(parameter, p), 
                        "Contains", 
                        new Type[] { typeof(string) },
                        constValue))
                    .Aggregate((a, c) => Expression.OrElse(a, c)),
                parameter);
        }
        
        movements = movements.Where(ContainsString<Movement>(SearchString));
