            XName operationElementName = XName.Get(Constants.OPERATION, Constants.WSDL_NS);
            XName policyReferenceElementName = XName.Get(Constants.POLICY_REFERENCE, Constants.NamespacePath.POLICY);
            XName policyElementName = XName.Get(Constants.POLICY, Constants.NamespacePath.POLICY);
            XName idAttributeName = XName.Get("Id", Constants.NamespacePath.WSSECURITY);
            
            var uriNo = from operation in wsdlDocument.Descendants(operationElementName)
                        where operation.HasAttributes && operation.Attribute(Constants.NAME).Value == _operationSelected
                        from policyReference in operation.Descendants(policyReferenceElementName)
                        where policyReference.HasAttributes && policyReference.Attribute(Constants.URI).Value.StartsWith(Constants.HASH)
                        select policyReference.Attribute(Constants.URI).Value.Substring(1);
            string uritemp = uriNo.FirstOrDefault().ToString();
            var operationPolicy = from policy in wsdlDocument.Descendants(policyElementName)
                                  where policy.HasAttributes && policy.Attribute(idAttributeName).Value == uritemp
                                  select policy;
                        
            string temp = operationPolicy.FirstOrDefault().ToString();
            return temp;
