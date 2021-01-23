                XDocument input = XDocument.Parse(@"<Root>
     <Companies>
      <Company>
       <ID>1</ID>
       <Name>Kalle</Name>
       <RegNo>1111</RegNo>
      </Company>
     </Companies>
     <Companies>
      <Company>
       <ID>1</ID>
       <Name>Kalle</Name>
       <RegNo>1112</RegNo>
      </Company>
     </Companies>  
    </Root>
    ");
                XDocument output =
                    new XDocument(
                        new XElement(input.Root.Name,
                            new XElement("Companies",
                                from comp in input.Root.Elements("Companies").Elements("Company")
                                group comp by (int)comp.Element("ID") into g
                                select new XElement("Company",
                                    new XElement("ID", g.Key),
                                    g.Elements("Name").First(),
                                    g.Elements("RegNo")
                                ))));
    
                output.Save(Console.Out);
