    public XmlSerializer GetSerializer(Type t) {
            if (!SerializerCache.ContainsKey(t.FullName)) {
                SerializerCache.Add(t.FullName, new XmlSerializer(t)); // Error occurs here, intermittently
            }
            return SerializerCache[t.FullName];
        }
