        /// <summary>
        /// Convert a lambda expression for a getter into a setter
        /// </summary>
        public static Action<T, U> GetSetter<T,U>(Expression<Func<T, U>> expression)
        {
            var memberExpression = (MemberExpression)expression.Body;
            var property = (PropertyInfo)memberExpression.Member;
            var setMethod = property.GetSetMethod();
            var parameterT = Expression.Parameter(typeof(T), "x");
            var parameterU = Expression.Parameter(typeof(U), "y");
            var newExpression =
                Expression.Lambda<Action<T, U>>(
                    Expression.Call(parameterT, setMethod, parameterU),
                    parameterT,
                    parameterU
                );
            return newExpression.Compile();
        }
