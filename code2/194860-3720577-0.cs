    IEnumerable<XElement> results = from c in XDocument.Load("input.xml").Elements("SourceXML").Elements("Issue")
                                    where c.Element("Fields").Element("Number").Value == "8" || c.Element("Fields").Element("Number").Value == "11"
                                    select c;
                
    XDocument resultXML = new XDocument();
    resultXML.Add(new XElement("SourceXML"));
    resultXML.Element("SourceXML").Add(results);
    resultXML.Save("output.xml");
