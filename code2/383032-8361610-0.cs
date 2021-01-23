    public string GetProtocolHeaderValue(string name)
    {
       IHeader header = GetProtocolHeader(name);
       return RetrieveHeaderValue(IHeader header);
    }
