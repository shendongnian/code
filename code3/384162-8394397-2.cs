    static class XElementExtensions
    {
        public static decimal? ToNullableDecimal(this XElement elem)
        {
            return elem.IsEmpty ? null : (decimal?)elem;
        }
    }
