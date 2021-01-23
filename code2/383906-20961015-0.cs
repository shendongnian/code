        public static IEnumerable<KeyValuePair<string, string>> ToIEnumerable(this NameValueCollection nvc)
        {
            foreach (string key in nvc.AllKeys)
            {
                yield return new KeyValuePair<string, string>(key, nvc[key]);
            }
        }
