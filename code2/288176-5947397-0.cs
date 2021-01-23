        public Uri GetUri(dynamic obj)
        {
            return GetUriImpl(obj);
        }
        private Uri GetUriImpl(Entry entry)
        {
            ...
        }
        private Uri GetUriImpl(EntryComment comment)
        {
            ...
        }
    In this case you'd probably want some sort of "backstop" method in case it's not a known type.
