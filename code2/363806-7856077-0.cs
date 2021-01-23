    class Dict3D
    {
        private Dictionary<KeyValuePair<object,object>, object> innnerDict= new Dictionary<KeyValuePair<object,object>, object>();
        public object Get(object key1, object key2)
        {
            KeyValuePair<object,object> bigKey = new KeyValuePair<object, object>(key1, key2);
            if (innnerDict.ContainsKey(bigKey))
            {
                return innnerDict[bigKey];
            }
            return null;
        }
        public void Set(object key1, object key2, object somevalue)
        {
            KeyValuePair<object, object> bigKey = new KeyValuePair<object, object>(key1, key2);
            if (innnerDict.ContainsKey(bigKey))
            {
                innnerDict[bigKey] = somevalue;
            }
            else
            {
                innnerDict.Add(bigKey, somevalue);
            }
        }
    }
