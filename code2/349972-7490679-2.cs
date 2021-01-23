    [XmlElement("Bar")]
    public List<Bar> Bars
    {
        get { return bar_; }
        set { throw new NotSupportedException("This property 'Bars' cannot be set. This property is readonly."); }
    }
