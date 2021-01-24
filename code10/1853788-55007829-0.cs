            var xmlBody = @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <Visit>
       <Person>...</Person>
       <Name>...</Name>
       <Color>...</Color>
    </Visit>";
            var xdoc = XDocument.Parse(xmlBody);
            var nodeList = new List<string> { "Name", "LastName", "Color" };
            
            var intersectedElements = xdoc.Elements()
                .First() //<Visit>
                .Elements()
                .Where(element => nodeList.Contains(element.Name.LocalName));
            foreach (XElement child in intersectedElements)
            {
                Console.WriteLine($"{child.Name.LocalName}: {child.Value}");
            }
