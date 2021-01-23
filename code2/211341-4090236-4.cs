    public static class HtmlAgilityExtender
    {
        public static String ValueOrDefault(this HtmlAttribute attr)
        {
            return (attr != null) ? attr.Value : String.Empty;
        }
    }
