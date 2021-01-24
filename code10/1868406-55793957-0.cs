    XDocument responseDoc = XDocument.Load(@"XMLFile1.xml");
    XNamespace pr = "urn:oasis:names:tc:SAML:1.0:protocol";
    XNamespace ast = "urn:oasis:names:tc:SAML:1.0:assertion";
    
    
    XElement status = responseDoc.Element(pr + "Response").Element(pr + "Status");
    string statusCode = (string)status.Element(pr + "StatusCode").Attribute("Value");
    string statusMessage = (string)status.Element(pr + "StatusMessage");
    
    Console.WriteLine("Status code: {0}; message: {1}.", statusCode, statusMessage);
                
    XElement attStatement = responseDoc.Element(pr + "Response").Element(ast + "Assertion").Element(ast + "AttributeStatement");
    string surname = (string)attStatement.Elements(ast + "Attribute").First(a => a.Attribute("AttributeName").Value == "Surname").Element(ast + "AttributeValue");
    string firstname = (string)attStatement.Elements(ast + "Attribute").First(a => a.Attribute("AttributeName").Value == "FirstName").Element(ast + "AttributeValue");
    string nrn = (string)attStatement.Elements(ast + "Attribute").First(a => a.Attribute("AttributeName").Value == "NRN").Element(ast + "AttributeValue");
    
    Console.WriteLine("First name: {0}, last name: {1}; NRN: {2}", firstname, surname, nrn);
