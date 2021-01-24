     <field var='FORM_TYPE' type='hidden'>
         <value>urn:xmpp:http:upload:0</value>
Fortunetly I figured it out by myself:
    [XmlType("field")]
    public class Field
    {
        [XmlAttribute("var")]
        public string Var { get; set; }
        
    
        [XmlElement("value")]
        public string Value { get; set; }
       
    }
    [XmlType("query")]
    public class DiscoFileInfo
    {
        [XmlArray("x",Namespace = "jabber:x:data")]
        [XmlArrayItem("field", typeof(Field))]
        public List<Field> Fields { get; set; }
    }
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(DiscoFileInfo), "http://jabber.org/protocol/disco#info");
