    string tmp = null;
    if (some condition)
    {
        m_cache.TryGetValue("SomeKey", out tmp); 
    }    
    if (string.IsNullOrEmpty(tmp))
    {
        tmp = MagicFinder();
    }    
    obj.MyString = tmp;
    
