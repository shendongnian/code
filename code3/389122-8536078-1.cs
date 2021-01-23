    [XmlElement(ElementName = "MyElement")]
    public string CurrentValueElement
    {
        get
        {
            return Element.CurrentValue;
        }
        set
        {
            Element = new MyElement
                          {
                              CurrentValue = value, PreviousValue = value
                          };
        }
    }
