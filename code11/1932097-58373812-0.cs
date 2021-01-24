    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.jcp.org/jcr/sv/1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.jcp.org/jcr/sv/1.0", IsNullable = false)]
    public partial class node
    {
    
        private nodeProperty[] propertyField;
    
        private string nameField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("property")]
        public nodeProperty[] property
        {
            get
            {
                return this.propertyField;
            }
            set
            {
                this.propertyField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string name
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
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.jcp.org/jcr/sv/1.0")]
    public partial class nodeProperty
    {
    
        private string valueField;
    
        private string nameField;
    
        private string typeField;
    
        private bool multipleField;
    
        private bool multipleFieldSpecified;
    
        /// <remarks/>
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string name
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
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public bool multiple
        {
            get
            {
                return this.multipleField;
            }
            set
            {
                this.multipleField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool multipleSpecified
        {
            get
            {
                return this.multipleFieldSpecified;
            }
            set
            {
                this.multipleFieldSpecified = value;
            }
        }
    }
