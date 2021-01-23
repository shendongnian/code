    static object serializerCacheLock = new object();
    public XmlSerializer GetSerializer(Type t) {
            if (!SerializerCache.ContainsKey(t.FullName))
            lock(serializerCacheLock)
            if (!SerializerCache.ContainsKey(t.FullName)) {
                SerializerCache.Add(t.FullName, new XmlSerializer(t));
            }
            return SerializerCache[t.FullName];
        }
