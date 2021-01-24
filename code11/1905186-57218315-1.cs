    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/cXML")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/cXML", IsNullable = false)]
        public partial class Identity
        {
    
            private string lastChangedTimestampField;
    
            private string[] textField;
    
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string lastChangedTimestamp
            {
                get
                {
                    return this.lastChangedTimestampField;
                }
                set
                {
                    this.lastChangedTimestampField = value;
                }
            }
    
            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string[] Text
            {
                get
                {
                    return this.textField;
                }
                set
                {
                    this.textField = value;
                }
            }
        }
