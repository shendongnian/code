    var doc = XDocument.Load(url);
    var tournaments = doc.Root
                         .Elements("category")
                         .Where(x => (string) x.Attribute("name") == "Tournament")
                         .Single(); // Is there only one matching catgeory?
    var matches = tournaments
        .Elements("match")
        .Select(m => new
                {
                   LocalTeam = (string) m.Element("localteam").Attribute("name"),
                   VisitorTeam = (string) m.Element("localteam").Attribute("name"),
                   Events = m.Elements("Events")
                             .Select(e => new
                                     {
                                         Player = (string) e.Attribute("player"),
                                         Type = (string) e.Attribute("type"),
                                         // etc
                                     })
                             .ToList();
                });
