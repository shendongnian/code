        public static RouteValueDictionary ToRouteValueDictionary(this NameValueCollection collection)
        {
            RouteValueDictionary dic = new RouteValueDictionary();
            foreach (string key in collection.Keys)
                dic.Add(key, collection[key]);
            return dic;
        }
        public static RouteValueDictionary AddOrUpdate(this RouteValueDictionary dictionary, string key, object value)
        {
            dictionary[key] = value;
            return dictionary;
        }
        public static RouteValueDictionary RemoveKeys(this RouteValueDictionary dictionary, params string[] keys)
        {
            foreach (string key in keys)
                dictionary.Remove(key);
            return dictionary;
        }
