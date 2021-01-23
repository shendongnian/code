    void Main()
    {
        Enum.Parse(typeof(SelectVersionEnum), "12").Dump();
        Enum.Parse(typeof(SelectVersionEnum), "14").Dump();
        Enum.Parse(typeof(SelectVersionEnum), "2007").Dump();
    }
    
    public enum SelectVersionEnum
    {
        Version2007 = 12,
        Version2010 = 14
    }
