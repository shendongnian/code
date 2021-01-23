     List<String>l_lstName = XDocument.Load("foo.xml")
                                   .Descendants("Sibling")
                                   .Select(Temp => Temp.Attribute("Name").Value).ToList();
            Dictionary<String, CXmlData> dict = new Dictionary<string, CXmlData>();
            
            ILookup<string, string> lookup = XDocument.Load("foo.xml")
                                  .Descendants("Children")
                                  .First()
                                  .Elements("Node")
                                  .ToLookup(x => (string)x.Attribute("val"),
                                            x => (string)x.Attribute("Name"));
            dict = XDocument.Load("foo.xml")
                                   .Descendants("Sibling").ToDictionary(
                                   X => X.Attribute("Name").Value,
                                   X => new CXmlData
                                   {
                                       lst =l_lstName.Select(temp=>lookup[temp].ToList()).ToList()[0],
                                       Data1 = X.Attribute("Xpos").Value == "0" ? "2" : X.Attribute("Ypos").Value,
                                       Data2 = X.Attribute("Xpos").Value
                                   }
                                   );
