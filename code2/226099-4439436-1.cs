    public class A : IXmlSerializable
    {
        public virtual void WriteXml (XmlWriter writer)
        {
            // Serialize A members
        }
    
        public virtual void ReadXml (XmlReader reader)
        {
            // Deserialize A members
        }
    
        public XmlSchema GetSchema()
        {
            return(null);
        }
    
    
    }
    
    
    public class B : A
    {
        public override void WriteXml (XmlWriter writer)
        {
            base.WriteXml(writer);
    
            // Serialize B members
        }
    
        public virtual void ReadXml (XmlReader reader)
        {
            base.ReadXml(reader);
    
            // Deserialize B members
        }
    }
