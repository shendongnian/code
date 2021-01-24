        private static Expression<Func<T, TResult>> ConstructMethodCallExpressionFunc<T, TResult>(string mehodName)
        {
            var methodInfo = typeof(T).GetMethod(mehodName);
            var argumentExpression = Expression.Parameter(typeof(T));
            var methodExpression = Expression.Call(
                argumentExpression,
                methodInfo,
                methodInfo.GetParameters().Select(pi => Expression.Call(
                    typeof(It), "IsAny", new Type[] { pi.ParameterType }, new Expression[0])));
            var result = Expression.Lambda<Func<T, TResult>>(
                methodExpression,
                argumentExpression);
            return result; //E.g.: Expression<Func<IService, string>>(s => s.SomeMethod(It.IsAny<int>(), It.IsAny<int>())
        }
