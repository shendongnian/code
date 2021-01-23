    public bool TryGetType(string contentTypeName, out SPContentType result)
    {
        foreach (SPContentType type in sPContentTypeCollection)
        {
            if (type.Name == contentTypeName)
            {
                result = type;
                return true;
            }
        }
        result = default(SPContentType);
        return false;
    }
