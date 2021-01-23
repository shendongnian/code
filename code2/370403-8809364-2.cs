    /// <remarks/>
            [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.openuri.org/InformacionPoliza", RequestNamespace = "http://www.openuri.org/", ResponseNamespace = "http://www.openuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            [return: System.Xml.Serialization.XmlElementAttribute("Poliza", Namespace = "http://www.example.org/PolizasBanorteSchema")]
            public Poliza InformacionPoliza(CriteriosPoliza CriteriosPoliza)
            {
                object[] results = this.Invoke("InformacionPoliza", new object[] {
                        CriteriosPoliza});
                return ((Poliza)(results[0]));
            }
