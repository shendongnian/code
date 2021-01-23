    private float[] _numbers;
    [XmlAttribute(AttributeName = "numbers")]
    public string Numbers
    {
        get
        {
            return string.Join(",", _numbers);
        }
    }
