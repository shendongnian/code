    static class ExpressionHelper
    {
        private static readonly DataTable dt = new DataTable();
        private static readonly Dictionary<string, string> expressionCache = new Dictionary<string, string>();
        private static readonly Dictionary<string, object> resultCache = new Dictionary<string, object>();
        // to be amended with necessary transforms
        private static readonly (string old, string @new)[] tokens = new[] { ("&&", "AND"), ("||", "OR") };
        public static T Compute<T>(this string expression, params (string name, object value)[] arguments) =>
            (T)Convert.ChangeType(expression.Transform().GetResult(arguments), typeof(T));
        private static object GetResult(this string expression, params (string name, object value)[] arguments)
        {
            foreach (var arg in arguments)
                expression = expression.Replace(arg.name, arg.value.ToString());
            if (resultCache.TryGetValue(expression, out var result))
                return result;
            return resultCache[expression] = dt.Compute(expression, string.Empty);
        }
        private static string Transform(this string expression)
        {
            if (expressionCache.TryGetValue(expression, out var result))
                return result;
            result = expression;
            foreach (var t in tokens)
                result = result.Replace(t.old, t.@new);
            return expressionCache[expression] = result;
        }
    }
