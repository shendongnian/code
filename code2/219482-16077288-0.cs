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
