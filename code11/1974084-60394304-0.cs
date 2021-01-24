    public TYPE GetParam<TYPE>(ICacheKey key)
    {
        if (typeof(TYPE) == typeof(string))
        {
            return (TYPE)((object)m_AppConfigCache.GetParamString(key.GroupName, key.Key));
        }
        else if (typeof(TYPE) == typeof(bool))
        {
            return (TYPE)((object)m_AppConfigCache.GetParamBool(key.GroupName, key.Key));
        }
    
        return default(TYPE);
    }
