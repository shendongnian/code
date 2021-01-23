        private static Dictionary<Type, Func<object, Uri>> UriProviders = 
            new Dictionary<Type, Func<object, Uri>>() {   
            { typeof(Entry), value => ... },
            { typeof(EntryComment), value => ... },
            { typeof(Blog), value => ... },
        };
    and then:
        public Uri GetUri(object obj)
        {
            Func<object, Uri> provider;
            if (!UriProviders.TryGetValue(obj.GetType(), out provider))
            {
                // Handle unknown type case
            }
            return provider(obj);
        }
    Note that this *won't* cover the case where you receive a subtype of `Entry` etc.
