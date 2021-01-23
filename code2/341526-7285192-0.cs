    public class Sports : IXmlSerializable
    {
        public string LotName { get; set; }
        
        public List<dynamic> Prices { get; set; }
        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            Prices = new List<dynamic>();
            reader.Read();
            LotName = reader.ReadElementContentAsString("lot_name", "");
            reader.Read();
            while (reader.Name.StartsWith("divisions_"))
            {
                reader.Read();
                var i = reader.ReadElementContentAsString("divisions", "");
                var m = reader.ReadElementContentAsString("match", "");
                var p = reader.ReadElementContentAsString("pay", "");
                Prices.Add(new { ID = i, Match = m, Pay = p });
                reader.Read();
            }
        
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
    public class Games  {
        [XmlElement("sports")]
        public Sports Sports { get; set; }
    }
    [XmlRoot("body")]
    public class Body 
    {
        [XmlElement("games")]
        public Games Games { get; set; }
    }
