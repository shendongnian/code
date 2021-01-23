    public static class AutoMapperExtensions
    {
        public static void NullSafeMapFrom<T, TResult>(this IMemberConfigurationExpression<T> opt, Expression<Func<T, TResult>> sourceMemberExpression)
        {
            var sourceMember = sourceMemberExpression.Compile();
            opt.MapFrom(src =>
            {
                try
                {
                    return sourceMember(src);
                }
                catch (NullReferenceException)
                {}
                return default(TResult);
            });
        }
    }
