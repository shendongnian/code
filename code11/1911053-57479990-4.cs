    IEnumerable<Person> ReadPeople(XmlDocument document)
    {
        var result = new List<Person>();
        var root = document.DocumentElement;
        var personNodes = root.SelectNodes("Person");
        foreach (XmlElement personNode in personNodes)
        {
            var person = new Person
            {
                Name = personNode.SelectSingleNode("M[@id='Name']")?.Attributes["v"]?.Value,
                Haircolor = personNode.SelectSingleNode("M[@id='Haircolor']")?.Attributes["v"]?.Value,
                HairLength = personNode.SelectSingleNode("M[@id='HairLength']")?.Attributes["v"]?.Value,
                Year = personNode.SelectSingleNode("M[@id='Year']")?.Attributes["v"]?.Value
            };
            result.Add(person);
        }
        return result;
    }
