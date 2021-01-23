    public int GetHashCode(MyFile a)
    {
        int rt = ((a.compareName.GetHashCode() * 251 + a.size.GetHashCode())
                              * 251 + a.deepness.GetHashCode()) *251;
    
        return rt;
    
    }
