    public static class MoqExtension
    {
        public static void SetResult<T, TResult>(this Mock<T> mock, MethodInfo methodInfo, TResult result)
            where T : class
        {
            var expressions = new List<Expression>();
            // Create IsAny for each parameter
            foreach (var parameter in methodInfo.GetParameters())
            {
                var pType = parameter.ParameterType;
                var isAnyMethod = typeof(It).GetMethods((BindingFlags)(-1))
                    .Where(x => x.Name == "IsAny")
                    .First();
                var genericIsAnyMethod = isAnyMethod.MakeGenericMethod(pType);
                var isAnyExp = Expression.Call(genericIsAnyMethod);
                expressions.Add(isAnyExp);
            }
            // Create method call
            var argParam = Expression.Parameter(typeof(T), "x");
            var callExp = Expression.Call(argParam, methodInfo, expressions.ToArray());
            var lambda = Expression.Lambda<Func<T, TResult>>(callExp, argParam);
            // invoke setup method
            var mockType = mock.GetType();
            var setupMethod = mockType.GetMethods()
                .Where(x => x.Name == "Setup" && x.IsGenericMethod)
                .First();
            var genericMethod = setupMethod.MakeGenericMethod(typeof(TResult));
            var res = genericMethod.Invoke(mock, new object[] { lambda }) as ISetup<T, TResult>;
            res.Returns(result);
        }
    }
