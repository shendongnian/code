    public static class HeaderOperators
    {
        public static IDictionary<string, string> GetValues(IReadOnlyList<string> keys, IHeaderDictionary headers, string defaultValue)
        {
            var firstCollection = keys
                .Select(x => x.ToLower()).Intersect(headers.Keys.Select(x => x.ToLower()))
                .Select(k => new KeyValuePair<string, string>(k.ToLower(), headers[k.ToLower()]));
            var secondCollection = keys
                .Select(x => x.ToLower())
                .Where(k => !headers.Keys.Select(x => x.ToLower()).Contains(k.ToLower()))
                .Select(k => new KeyValuePair<string, string>(k.ToLower(), defaultValue));
            return
                firstCollection.Union(secondCollection).ToDictionary(p => p.Key.ToLower(), p => p.Value);
        }
    }
