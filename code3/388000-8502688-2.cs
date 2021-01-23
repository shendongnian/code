    public partial class ParametersParameterParameterValue {
        
        [System.Xml.Serialization.XmlArrayAttribute(
            Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
            
        [System.Xml.Serialization.XmlArrayItemAttribute(
            "ReturnParameter", 
            typeof(ParametersParameterParameterValueReturnParametersReturnParameter), 
            Form=System.Xml.Schema.XmlSchemaForm.Unqualified, 
            IsNullable=false)]
            
        public ParametersParameterParameterValueReturnParametersReturnParameter[][] 
            ReturnParameters { get; set; }
        
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text { get; set; }
    }
