    [Serializable]
    public class MyObject
    {
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
        [XmlElement(ElementName = "MyOtherElement")]
        public string CurrentValueOtherElement
        {
            get
            {
                return OtherElement.CurrentValue;
            }
            set {}
        }
        [XmlIgnore]
        public MyElement Element { get; set; }
        [XmlIgnore]
        public MyElement OtherElement { get; set; }
    }
