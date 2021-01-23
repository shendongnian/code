    readonly Dictionary<string, object> locks = new Dictionary<string, object>();
    readonly object dictionaryLock = new object();
    string Get(string key) {
        object bodyLock;
        lock (dictionaryLock) {
            if (!dictionary.TryGetValue(key, out bodyLock)) {
                bodyLock = new object();
                dictionary[key] = bodyLock;
            }
        }
        lock (bodyLock) {
            ...
        }
    }
