    [XmlRoot("DATASET")]
    public class DS
    {
        [XmlElement("SITE_ID")]
        public string Site ="";
        [XmlElement("DATA")]
        public Data[] data = null;
    }
    [XmlRoot("DATA")]
    public class Data
    {
        [XmlAttribute("type")]
        public string Type ="";
        [XmlAttribute("id")]
        public string Id ="";
        [XmlText]
        public string Text = "";
    }
    XmlSerializer xs = new XmlSerializer(typeof(DS));
    var obj = xs.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlstring)));
    MemoryStream m = new MemoryStream();
    xs.Serialize(m,obj);
    MessageBox.Show(Encoding.UTF8.GetString(m.ToArray()));
