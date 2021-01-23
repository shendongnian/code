    [XmlElement(IsNullable = true)] public decimal? XXX;
    public bool ShouldSerializeXXX()
    {
       return XXX.HasValue;
    }
