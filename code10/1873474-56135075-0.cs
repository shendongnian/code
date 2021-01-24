    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://temp")]
    [System.Xml.Serialization.XmlRootAttribute("NumberType", Namespace = "http://temp", IsNullable = false)]    
    public partial class IdGroup
    {
        private string idField;
        private string valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        [CustomPropertyAttribute("TableName", "ColumnName", Level2Type)]
        [CustomPropertyAttribute("AltTableName", "AltColumnName", AltLevel2Type)]
        public string Value
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
    }
    public partial class IdGroup : IExtendFunctionality
    { }
