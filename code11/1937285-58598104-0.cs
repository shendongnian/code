private string bValueField;
[System.Xml.Serialization.XmlIgnore]
public byte[] aValue { get; set; }
        
[System.Xml.Serialization.XmlAttribute("aValue")]
public string bValue
{
    get
    {
        return bValueField;
    }
    set
    {
        if (value.Contains("string identifier here")) // i.e. it's not a byte[]
        {
            aValue = new byte[] { };
            bValueField = value;
        }
        else // it's a byte[]
        {
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream(Encoding.Unicode.GetBytes(value ?? "")))
            {
                aValue = (byte[])formatter.Deserialize(stream);
                bValueField = "not a string";
            }
        } 
    }
}
