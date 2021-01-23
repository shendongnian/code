    using Configuration;
    var nodeListSection = ConfigurationManager.GetSection("NodeList") as Configuration.NodeListSection;
    var newNode = new NodeElement() { Name = "xyz", IsDefault = false, Description = "New Guy" };
    nodeListSection.Nodes.Add(newNode);
    Configuration.Save(ConfigurationSaveMode.Modified);
