        public static Action<T, object> GenerateSetterAction<T>(PropertyInfo pi)
        {
            //p=> p.<pi>=(pi.PropertyType)v
            var expParamP = Expression.Parameter(typeof(T), "p");
            var expParamV = Expression.Parameter(typeof(object), "v");
            var expParamVc = Expression.Convert(expParamV, pi.PropertyType);
            var mma = Expression.Call(
                    expParamP
                    , pi.GetSetMethod()
                    , expParamVc
                );
            var exp = Expression.Lambda<Action<T, object>>(mma, expParamP, expParamV);
            return exp.Compile();
        }
