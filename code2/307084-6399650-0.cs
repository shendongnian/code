    private static Player GetPlayer(string name, XElement simpleKD)
    {
        var playerElem = simpleKD.Elements("player")
                                 .SingleOrDefault(p => p.Attribute("name").Value == name);
        if (playerElem == null)
        {
            simpleKD.Add(new XElement("player",
                                      new XAttribute("name", name),
                                      new XElement("kills", 0),
                                      new XElement("deaths", 0)));
            return new Player(name);
        }
        return new Player(name,
                          (int)playerElem.Element("kills"),
                          (int)playerElem.Element("deaths"));
    }
