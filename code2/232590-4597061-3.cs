    public static class RouteValueExtensions
    {
        public static void Merge(this RouteValueDictionary routeValuesA, object routeValuesB)
        {
            foreach (var entry in new RouteValueDictionary(routeValuesB))
            {
                routeValuesA[entry.Key] = entry.Value;
            }
        }
        public static RouteValueDictionary With(this RouteValueDictionary routeValuesA, object routeValuesB)
        {
            routeValuesA.Merge(routeValuesB);
            return routeValuesA;
        }
        public static RouteValueDictionary With(this RouteValueDictionary routeValues, params object[] routeValuesToMerge)
        {
            if (routeValues != null)
            {
                for (int i = 0; i < routeValuesToMerge.Length; i++)
                {
                    routeValues.Merge(routeValuesToMerge[i]);
                }
            }
            return routeValues;
        }
        public static RouteValueDictionary RouteValues(this HtmlHelper htmlHelper, object routeValues)
        {
            return new RouteValueDictionary(routeValues);
        }
        public static RouteValueDictionary RouteValues(this HtmlHelper htmlHelper, object routeValuesA, object routeValuesB)
        {
            return htmlHelper.RouteValues(routeValuesA).With(routeValuesB);
        }
        public static RouteValueDictionary RouteValues(this HtmlHelper htmlHelper, params object[] routeValues)
        {
            if (routeValues != null && routeValues.Length > 0)
            {
                var result = htmlHelper.RouteValues(routeValues[0]);
                for (int i = 1; i < routeValues.Length; i++)
                {
                    result.Merge(routeValues[i]);
                }
                return result;
            }
            else
            {
                return new RouteValueDictionary();
            }
        }
    }
