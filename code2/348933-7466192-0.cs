    List<dynamic> items = XDocument
        .Load("input.xml")
        .Element("items")
        .Elements("item")
        .Select(item =>
        {
            IDictionary<string, object> dict = new ExpandoObject();
            foreach (var element in item.Elements())
                dict[element.Name.LocalName] = (string)element;
            return (dynamic)dict;
        })
        .ToList();
