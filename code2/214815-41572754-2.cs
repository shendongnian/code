    public sealed class LargeJsonValueProviderFactory : ValueProviderFactory
    {
        private static void AddToBackingStore(LargeJsonValueProviderFactory.EntryLimitedDictionary backingStore, string prefix, object value)
        {
            IDictionary<string, object> dictionary = value as IDictionary<string, object>;
            if (dictionary != null)
            {
                foreach (KeyValuePair<string, object> keyValuePair in (IEnumerable<KeyValuePair<string, object>>) dictionary)
                    LargeJsonValueProviderFactory.AddToBackingStore(backingStore, LargeJsonValueProviderFactory.MakePropertyKey(prefix, keyValuePair.Key), keyValuePair.Value);
            }
            else
            {
                IList list = value as IList;
                if (list != null)
                {
                    for (int index = 0; index < list.Count; ++index)
                        LargeJsonValueProviderFactory.AddToBackingStore(backingStore, LargeJsonValueProviderFactory.MakeArrayKey(prefix, index), list[index]);
                }
                else
                    backingStore.Add(prefix, value);
            }
        }
        private static object GetDeserializedObject(ControllerContext controllerContext)
        {
            if (!controllerContext.HttpContext.Request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
                return (object) null;
            string end = new StreamReader(controllerContext.HttpContext.Request.InputStream).ReadToEnd();
            if (string.IsNullOrEmpty(end))
                return (object) null;
            var serializer = new JavaScriptSerializer {MaxJsonLength = Int32.MaxValue};
            return serializer.DeserializeObject(end);
        }
        /// <summary>Returns a JSON value-provider object for the specified controller context.</summary>
        /// <returns>A JSON value-provider object for the specified controller context.</returns>
        /// <param name="controllerContext">The controller context.</param>
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            if (controllerContext == null)
                throw new ArgumentNullException("controllerContext");
            object deserializedObject = LargeJsonValueProviderFactory.GetDeserializedObject(controllerContext);
            if (deserializedObject == null)
                return (IValueProvider) null;
            Dictionary<string, object> dictionary = new Dictionary<string, object>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
            LargeJsonValueProviderFactory.AddToBackingStore(new LargeJsonValueProviderFactory.EntryLimitedDictionary((IDictionary<string, object>) dictionary), string.Empty, deserializedObject);
            return (IValueProvider) new DictionaryValueProvider<object>((IDictionary<string, object>) dictionary, CultureInfo.CurrentCulture);
        }
        private static string MakeArrayKey(string prefix, int index)
        {
            return prefix + "[" + index.ToString((IFormatProvider) CultureInfo.InvariantCulture) + "]";
        }
        private static string MakePropertyKey(string prefix, string propertyName)
        {
            if (!string.IsNullOrEmpty(prefix))
                return prefix + "." + propertyName;
            return propertyName;
        }
        private class EntryLimitedDictionary
        {
            private static int _maximumDepth = LargeJsonValueProviderFactory.EntryLimitedDictionary.GetMaximumDepth();
            private readonly IDictionary<string, object> _innerDictionary;
            private int _itemCount;
            public EntryLimitedDictionary(IDictionary<string, object> innerDictionary)
            {
                this._innerDictionary = innerDictionary;
            }
            public void Add(string key, object value)
            {
                if (++this._itemCount > LargeJsonValueProviderFactory.EntryLimitedDictionary._maximumDepth)
                    throw new InvalidOperationException("JsonValueProviderFactory_RequestTooLarge");
                this._innerDictionary.Add(key, value);
            }
            private static int GetMaximumDepth()
            {
                NameValueCollection appSettings = ConfigurationManager.AppSettings;
                if (appSettings != null)
                {
                    string[] values = appSettings.GetValues("aspnet:MaxJsonDeserializerMembers");
                    int result;
                    if (values != null && values.Length > 0 && int.TryParse(values[0], out result))
                        return result;
                }
                return 1000;
            }
        }
    }
