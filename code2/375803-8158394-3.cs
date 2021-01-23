    public static class FormatAsHtmlExtensions
    {
        public static IEnumerable<string> FormatAsHtml<K,V>(this IDictionary<K, V> dict, string format)
        {
            foreach (var pair in dict)
                yield return HttpServerUtility.HtmlEncode(string.Format(format, pair.Key, pair.Value));
        }
        public static IEnumerable<string> FormatAsHtml<K,V>(this IDictionary<K, V> dict)
        {
            return FormatAsHtml("{0}, {1}");
        }
    }
