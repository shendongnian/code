    class Symbol
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
  
    XDocument doc = XDocument.Load("test.xml");
    var symbols = doc.Descendants("SYMBOL")
                     .Select(x => new Symbol 
                      { 
                        Code = (string)x.Attribute("Code"), 
                        Name = (string)x.Attribute("Name") 
                      })
                     .ToList();
