    public class ViewAsHex
    {
        [XmlIgnore]
        public int Value { get; set; }
        [XmlElement(ElementName="Value")]
        public string HexValue
        {
            get
            {
                // convert int to hex representation
                return Value.ToString("x");
            }
            set
            {
                // convert hex representation back to int
                Value = int.Parse(value, 
                    System.Globalization.NumberStyles.HexNumber);
            }
        }
    }
