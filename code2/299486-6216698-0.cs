    public string GetMetadata(string metaDataKey)
    {
        try
        {
            string val = _Metadata[metaDataKey].TrimEnd();
            return val;
        }
        catch (KeyNotFoundException ex)
        {
            // or your own custom MetaDataNotFoundException or some such
            throw new KeyNotFoundException(string.Format("There is no metadata that contains the key '{0}'!", metaDataKey));
        }
    }
