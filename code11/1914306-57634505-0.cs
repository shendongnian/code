    public MemoryConfigurationProvider(MemoryConfigurationSource source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        _source = source;
        if (_source.InitialData != null)
        {
            foreach (var pair in _source.InitialData)
            {
                Data.Add(pair.Key, pair.Value);
            }
        }
    }
