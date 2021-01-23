    public long DataSize { get; set; }
    public EnumDataType DataType { get; set; }
    public DataRequest()
    {
        DataSize = 0; // Not really required; default anyway
        DataType = EnumDataType.Apple;
    }
