    [XmlRoot(DataType = "setConfigurationResponse", ElementName = "setConfigurationResponse")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
        [System.ServiceModel.MessageContractAttribute(WrapperName = "setConfigurationResponse", WrapperNamespace = "mynamespace", IsWrapped = false)]
        [XmlRoot(DataType = "setConfigurationResponse", ElementName = "setConfigurationResponse")] 
        public partial class setConfigurationResponse
        {
    
            [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "mynamespace", Order = 0)]
            [System.Xml.Serialization.XmlElementAttribute("return", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public transaction[] @return;
    
            public setConfigurationResponse()
            {
            }
    
            public setConfigurationResponse(transaction[] @return)
            {
                this.@return = @return;
            }
        }
