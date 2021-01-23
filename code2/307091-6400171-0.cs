        private  Player GetPlayer(string name, XElement simpleKD)
        {
            var playerElem = simpleKD.Descendants("player").SingleOrDefault(x => x.Attribute("name").Value.Equals(name));
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
        class Player
        {
            public string Kills { get; set; }
            public string Deaths { get; set; }
            public Player() { }
            public Player(string name) { }
            public Player(string name, int kills, int deaths) { }
        }
