    var xdoc = XDocument.Load(filename);
    var barElement = xdoc.Element("AggievilleBar");
    var specialElements = barElement.Descendants("special").ToList();
    var specials = new List<Special>();
    specialElements.ForEach(s =>
        {
            var dayOfWeek = Convert.ToInt32(s.Attribute("dayofweek").Value);
            var price = Convert.ToInt32(s.Attribute("price").Value);
            var date = s.Attribute("date");
            specials.Add(new Special
            {
                Name = s.Value,
                DayOfWeek = dayOfWeek,
                Price = price,
                Date = date != null ? DateTime.Parse(date.Value) : DateTime.MinValue
            });
        });
    var bar = new Bar() {
        Name = barElement.Element("name").Value,
        PictureVersion = Convert.ToInt32(barElement.Elements("picture").Single()
            .Attribute("version").Value),
        Location = barElement.Element("location").Value,
        Description = barElement.Element("description").Value,
        News = barElement.Element("news").Value,
        Specials = specials
    };
    return bar;
