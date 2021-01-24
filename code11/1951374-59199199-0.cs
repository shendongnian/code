       string strVarCallResult = string.Empty;  
                string ClaimUserID = string.Empty;  
                string ClaimEmployeeID = string.Empty;  
                 
                try  
                {  
                    foreach (string s in Request.Params.Keys)  
                    {  
                        if (s.ToString() == "SAMLResponse")  
                        {  
                            rawSamlData = Request.Params[s];  
                            break;  
                        }  
                    }  
                      
                    byte[] samlData = Convert.FromBase64String(rawSamlData);  
          
                    // read back into a UTF string  
                    string samlAssertion = Encoding.UTF8.GetString(samlData);  
          
                    XmlDocument doc = new XmlDocument();  
                    XmlNamespaceManager xMan = new XmlNamespaceManager(doc.NameTable);  
                    xMan.AddNamespace("saml2p", "urn:oasis:names:tc:SAML:2.0:protocol");  
                    xMan.AddNamespace("saml2", "urn:oasis:names:tc:SAML:2.0:assertion");  
                    xMan.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#");  
          
                    doc.LoadXml(Encoding.UTF8.GetString(samlData));  
                    //Response.Write(doc.LastChild.ChildNodes[3].ChildNodes[2].ChildNodes[0].InnerXml);  
                    XmlNode xNode = doc.SelectSingleNode("/saml2p:Response/saml2:Assertion/saml2:Subject/saml2:NameID", xMan);  
                      
                    if (xNode != null)  
                    {  
                        UserId = xNode.InnerText;  
                        ClaimUserID = xNode.InnerText;  
                         
                    }  
        }  
                catch (Exception ex)  
                {  
                     
                }  
