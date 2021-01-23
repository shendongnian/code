     private string GetPolicy()
            {
                XDocument wsdlDocument = XDocument.Load(_wsdlPath);
                           
                XName operationElementName = XName.Get("operation", "http://schemas.xmlsoap.org/wsdl/");
                XName policyReferenceElementName = XName.Get("PolicyReference", "http://schemas.xmlsoap.org/ws/2004/09/policy");
                XName policyElementName = XName.Get("Policy", "http://schemas.xmlsoap.org/ws/2004/09/policy");
                XName idAttributeName = XName.Get("Id", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wsswssecurity-utility-1.0.xsd");
    
                var operationPolicy = from operation in wsdlDocument.Descendants(operationElementName)
                                      where operation.Attribute("name").Value == _operationSelected
                                      from policyReference in operation.Descendants(policyReferenceElementName)
                                      where policyReference.Attribute("URI").Value.StartsWith("#")
                                      let uri = policyReference.Attribute("URI").Value.Substring(1)
                                      from policy in wsdlDocument.Descendants(policyElementName)
                                      where policy.Attribute(idAttributeName).Value == uri            
                                      select policy.ToString();
    
                #region Removing Embedded Namespaces
                string temp = operationPolicy.FirstOrDefault();
                if (temp.Contains(Constants.WSPolicyNsURI.XMLNS_SP) || temp.Contains(Constants.WSPolicyNsURI.XMLNS_WSP) || temp.Contains(Constants.WSPolicyNsURI.XMLNS_WSU))
                {
                    temp = temp.Replace(Constants.WSPolicyNsURI.XMLNS_SP, String.Empty);
                    temp = temp.Replace(Constants.WSPolicyNsURI.XMLNS_WSP, String.Empty);
                    temp = temp.Replace(Constants.WSPolicyNsURI.XMLNS_WSU, String.Empty);
                }
                
                #endregion
                return temp;
            }
