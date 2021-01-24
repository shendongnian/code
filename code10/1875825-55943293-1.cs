    using System.Xml.Serialization;
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/XMLSchema.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/XMLSchema.xsd", IsNullable=false)]
    public partial class MyClass {
        
        private MyClassMyStringEnum myStringEnumField;
        
        private int myIntEnumField;
        
        /// <remarks/>
        public MyClassMyStringEnum MyStringEnum {
            get {
                return this.myStringEnumField;
            }
            set {
                this.myStringEnumField = value;
            }
        }
        
        /// <remarks/>
        public int MyIntEnum {
            get {
                return this.myIntEnumField;
            }
            set {
                this.myIntEnumField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/XMLSchema.xsd")]
    public enum MyClassMyStringEnum {
        
        /// <remarks/>
        Val1,
        
        /// <remarks/>
        Val2,
        
        /// <remarks/>
        Val3,
    }
