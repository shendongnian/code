    public class StringExtensions
    {
        public static bool ContainsIgnoringCase(string str, string substring)
        {
            return str.IndexOf(substring, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
    ...
    public static class ExpressionRetriever
    {
        ...
        private static MethodInfo containsIgnoringCaseMethod = typeof(StringExtensions).GetMethod("ContainsIgnoringCase", new Type[] { typeof(string), typeof(string)});
        public static Expression GetExpression<T>(ParameterExpression param, ExpressionFilter filter)
        {
            ...
            switch (filter.Comparison)
            {
                ...
                case Comparison.Contains:
                    return Expression.Call(null, containsIgnoringCaseMethod, member, constant);
            }
        }
    }
