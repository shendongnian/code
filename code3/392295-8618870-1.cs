        private string GetPolicy(string pWsdlPath, string pOperationName)
        {
            XDocument xDoc = XDocument.Load(pWsdlPath);
            XName operationElementName = XName.Get("operation", "http://schemas.xmlsoap.org/wsdl/");
            XName policyReferenceElementName = XName.Get("PolicyReference", "http://schemas.xmlsoap.org/ws/2004/09/policy");
            XName policyElementName = XName.Get("Policy", "http://schemas.xmlsoap.org/ws/2004/09/policy");
            XName idAttributeName = XName.Get("Id", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wsswssecurity-utility-1.0.xsd");
            var operationPolicy = from operation in wsdlDocument.Descendants(operationElementName)
                                  where operation.Attribute("name").Value == "concat"
                                  from policyReference in operation.Descendants(policyReferenceElementName)
                                  where policyReference.Attribute("URI").Value.StartsWith("#")
                                  let uri = policyReference.Attribute("URI").Value.Substring(1)
                                  from policy in wsdlDocument.Descendants(policyElementName)
                                  where policy.Attribute(idAttributeName).Value == uri
                                  select policy.ToString();
            return operationPolicy.FirstOrDefault();
        }
