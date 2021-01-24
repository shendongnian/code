    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class XML1
    {
        private string name1Field;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name1
        {
            get
            {
                return this.name1Field;
            }
            set
            {
                this.name1Field = value;
            }
        }
    }
	
	XmlSerializer serializer = new XmlSerializer(typeof(XML1));
    using (StringReader reader = new StringReader("<XML1 Name1=\"Test\"></XML1>"))
    {
         XML1 root = (XML1)(serializer.Deserialize(reader));
         string NameValue = root.Name1;
    }
