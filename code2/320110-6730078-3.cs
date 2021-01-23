    [XmlRoot("foo")]
    public class SerializePlease
    {
        [XmlIgnore]
        public BigInteger BigIntValue;
        [XmlElement("BigIntValue")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BigIntValueProxy
        {
            get
            {
                return BigIntValue.ToString();
            }
            set
            {
                BigIntValue = BigInteger.Parse(value);
            }
        }
    }
