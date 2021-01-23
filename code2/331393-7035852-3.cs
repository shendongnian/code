    namespace TestConsoleApplication1
    {
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
        public partial class Doc {
            
            private DocItem[] itemsField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public DocItem[] Items {
                get {
                    return this.itemsField;
                }
                set {
                    this.itemsField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
        public partial class DocItem {
            
            private string textField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Text {
                get {
                    return this.textField;
                }
                set {
                    this.textField = value;
                }
            }
        }
    }
