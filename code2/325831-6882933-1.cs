    // ConfigurationData is loaded as
    // XDocument.Load("file.xml").Root
    public string rule_GetFruitForThisSeason(Hamper design)
    {
            var node = ConfigurationData.Elements("hamper")
                .Elements("seasonalRules")
                .Elements("rule")
                .Where(a => int.Parse(a.Attribute("pty1").Value) > design.pty1 &&
                            int.Parse(a.Attribute("pty").Value) > design.pty)
                .FirstOrDefault();
            if (node == null) return null;
            return node.Attribute("fruit").Value;
    }
