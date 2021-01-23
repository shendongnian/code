    public static class OrderUtils
    {
        public static string ToStringForOrdering<T, TKey>(this Expression<Func<T, TKey>> expression, bool isDesc = false)
        {
            var str = expression.Body.ToString();
            var param = expression.Parameters.First().Name;
            str = str.Replace("Convert(", "(").Replace(param + ".", "");
            return str + (isDesc ? " descending" : "");
        }
    }
