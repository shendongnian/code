    [XmlIgnore]
    public int[] MyProperty { get; set; }
    [XmlAttribute("myAttribute")]
    public string _MyProperty
    {
        get
        {
            return string.Join(" ", MyProperty.Select(x => x.ToString()).ToArray());
        }
        set
        {
            MyProperty = value.Split(' ').Select(x => int.Parse(x)).ToArray();
        }
    }
