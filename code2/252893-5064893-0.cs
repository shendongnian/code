    // Load the xml from file
    XElement docElem = XElement.Load(path);
    // Get the Connections element. This code assumes there will always be exactly one.
    XElement connectionsElem = docElem.Elements("Connections").Single();
    
    // Check if there is already a Conn element with the equired attribute value combination
    if (!connectionsElem.Elements("Conn").Any(connElem =>
        (string)connElem.Attribute("ServerName") == serverName &&
        (string)connElem.Attribute("DataBase") == dataBase &&
        (string)connElem.Attribute("User") == user &&
        (string)connElem.Attribute("Pass") == pass)) {
    
        // Otherwise add such a Conn element
        connectionsElem.AddFirst(
            new XElement("Conn",
                new XAttribute("ServerName", serverName),
                new XAttribute("DataBase", dataBase),
                new XAttribute("User", user),
                new XAttribute("Pass", pass)
            )
        );
    }
    
    // Write the Xml to file again.
    docElem.Save(path);
