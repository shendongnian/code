    public static class LinqHelper
    {
        //Support IQueryable (Linq to Entities)
        public static IQueryable<TSource> WhereLike<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, string>> valueSelector, string value, char wildcard)
        {
            return source.Where(BuildLikeExpression(valueSelector, value, wildcard));
        }
    
        //Support IEnumerable (Linq to objects)
        public static IEnumerable<TSource> WhereLike<TSource>(this IEnumerable<TSource> sequence, Func<TSource, string> expression, string value, char wildcard)
        {
            var regEx = WildcardToRegex(value, wildcard);
    
            //Prevent multiple enumeration:
            var arraySequence = sequence as TSource[] ?? sequence.ToArray();
    
            try
            {
                return arraySequence.Where(item => Regex.IsMatch(expression(item), regEx));
            }
            catch (ArgumentNullException)
            {
                return arraySequence;
            }
        }
    
        //Used for the IEnumerable support
        private static string WildcardToRegex(string value, char wildcard)
        {
            return "(?i:^" + Regex.Escape(value).Replace("\\" + wildcard, "." + wildcard) + "$)";
        }
    
        //Used for the IQueryable support
        private static Expression<Func<TElement, bool>> BuildLikeExpression<TElement>(Expression<Func<TElement, string>> valueSelector, string value, char wildcard)
        {
            if (valueSelector == null) throw new ArgumentNullException("valueSelector");
    
            var method = GetLikeMethod(value, wildcard);
    
            value = value.Trim(wildcard);
            var body = Expression.Call(valueSelector.Body, method, Expression.Constant(value));
    
            var parameter = valueSelector.Parameters.Single();
            return Expression.Lambda<Func<TElement, bool>>(body, parameter);
        }
    
        private static MethodInfo GetLikeMethod(string value, char wildcard)
        {
            var methodName = "Equals";
    
            var textLength = value.Length;
            value = value.TrimEnd(wildcard);
            if (textLength > value.Length)
            {
                methodName = "StartsWith";
                textLength = value.Length;
            }
    
            value = value.TrimStart(wildcard);
            if (textLength > value.Length)
            {
                methodName = (methodName == "StartsWith") ? "Contains" : "EndsWith";
            }
    
            var stringType = typeof(string);
            return stringType.GetMethod(methodName, new[] { stringType });
        }
    }
