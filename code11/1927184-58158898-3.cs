    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class XML
    {
        private string nameField;
        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }
	
	XmlSerializer serializer = new XmlSerializer(typeof(XML));
    using (StringReader reader = new StringReader("<XML><Name>Test</Name></XML>"))
    {
         XML root = (XML)(serializer.Deserialize(reader));
         string NameValue = root.Name;
    }
