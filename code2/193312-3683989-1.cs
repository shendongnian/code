     List<String>l_lstName = XDocument.Load("foo.xml")
                                   .Descendants("Sibling")
                                   .Select(Temp => Temp.Attribute("Name").Value).ToList();
            Dictionary<String, CXmlData> dict = new Dictionary<string, CXmlData>();
            
          
            dict = XDocument.Load("foo.xml")
                                   .Descendants("Sibling").ToDictionary(
                                   X => X.Attribute("Name").Value,
                                   X => new CXmlData
                                   {
                                       lst =XDocument.Load("foo.xml").Descendants("Children").Descendants("Child").Where(Temp=>Temp.Attribute("val").Value==X.Attribute("Name").Value).Select(Temp=>Temp.Attribute("Name").Value).ToList(),
                                       Data1 = X.Attribute("Xpos").Value == "0" ? "2" : X.Attribute("Ypos").Value,
                                       Data2 = X.Attribute("Xpos").Value
                                   }
                                   );
