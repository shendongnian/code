    public string CreateEncryptedData(string key)
    {
        if (_blobs.TryGetValue(key, out var value))
            return value;
        lock (_encryptedDataLock)
        {
            return _blobs.TryAdd(key, x => CalulateEncryptedData());
        }
    }
