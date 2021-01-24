    public struct XmlDecimal : IXmlSerializable
    {
        public decimal Value { get; private set; }
        public XmlDecimal(decimal value) => Value = value;
        public XmlSchema GetSchema() => null;
        public void ReadXml(XmlReader reader)
        {
            var s = reader.ReadElementContentAsString();
            Value = decimal.TryParse(s, NumberStyles.Number | NumberStyles.AllowExponent,
                NumberFormatInfo.InvariantInfo, out var value)
                ? value
                : 0; // If parse fail the resulting value is 0. Maybe we can throw an exception here.
        }
        public void WriteXml(XmlWriter writer) => writer.WriteValue(Value);
        public static implicit operator decimal(XmlDecimal v) => v.Value;
        public override string ToString() => Value.ToString();
    }
