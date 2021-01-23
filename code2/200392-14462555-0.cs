    public struct HInt32 : IXmlSerializable
    {
    	private int _Value;
    
    	public HInt32(int v) { _Value = v; }
    
    	XmlSchema IXmlSerializable.GetSchema() { return null; }
    
    	void IXmlSerializable.ReadXml(XmlReader reader) { _Value = Int32.Parse(reader.ReadContentAsString().TrimStart('0', 'x'), NumberStyles.HexNumber); }
    
    	void IXmlSerializable.WriteXml(XmlWriter writer) { writer.WriteValue("0x" + _Value.ToString("X2").PadLeft(8, '0')); }
    
    	public static implicit operator int(HInt32 v) { return v._Value; }
    
    	public static implicit operator HInt32(int v) { return new HInt32(v); }
    }
