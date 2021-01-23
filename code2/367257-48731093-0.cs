    [XmlElement]
    public List<string> OptionalXyz {get; set;}
    public bool ShouldSerializeOptionaXyz() {
        return OptionalXyz != null && OptionalXyz.Count > 0 ;
    }
