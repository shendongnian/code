 lang-csh
        private static Expression<Func<TDocument, bool>> ByPropertyViaEqOr<TDocument>(string propName, string[] values)
        {
            var doc = Expression.Parameter(typeof(TDocument), "doc");
            var eq = values.Select(value => ByPropertyViaEq<TDocument>(propName, value));
            var orElse = eq.Aggregate((l, r) => Expression.OrElse(l, r));
            return Expression.Lambda<Func<TDocument, bool>>(orElse, doc);
        }
        private static Expression ByPropertyViaEq<TDocument>(string propName, string value)
        {
            var doc = Expression.Parameter(typeof(TDocument), "doc");
            var docProp = Expression.PropertyOrField(doc, propName);
            var propValue = Expression.Constant(value, typeof(string));
            return Expression.Equal(docProp, propValue);
        }
