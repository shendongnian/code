             var listOfStringsYouWant = new List<string>();
             var doc = XDocument.Load("placeXMLHere");
             // finds every node of item
             doc.Descendants("item").ToList()
                .ForEach(item =>
                            {
                               listOfStringsYouWant.Add(item.Element("name").Value.Replace('-', '\r\n'));
                            });
