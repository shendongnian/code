    using System.Xml.XPath;
    var document = XDocument.Parse(@"<Z>
                                      <X>
                                        <Code>ABC</Code>
                                      </X>
                                      <X>
                                        <Code>DEF</Code>
                                      </X>
                                     </Z>");
    
    var codeValues = document.XPathSelectElements("//Z/X/Code")
                              .Select(e => e.Value)
                              .OrderByDescending(e => e);
