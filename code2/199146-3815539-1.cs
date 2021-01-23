    [Serializable]
    public class Child
    {
        public Child()
        {
        }
    
        public string Foo { get; set; }
    
        [XmlIgnore]
        public Parent Parent { get; set; }
    }
    
    [Serializable]
    public class Parent
    {
        public Parent()
        {
        }
    
        #region IXmlSerializable Members
    
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }
    
        public void ReadXml(System.Xml.XmlReader reader)
        {
            //Reading Parent content
            //Reading Child
            Child.Parent = this;
        }
    
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            //Writing Parent and Child content
        }
    
        #endregion
    
        public string Boo { get; set; }
    
        public Child Child { get; set; }
    }
