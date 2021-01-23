      public void SaveXml(string path)
      {
        XElement xml;
        XElement root = new XElement("Cards");
        foreach (var item in Cards)
        {
            xml = new XElement("Card",
                    new XAttribute("name", item.Name),
                    new XElement("Type", item.Type),
                    new XElement("Image",
                    new XAttribute("path", item.Image)),
                    new XElement("Usage", item.Usage),
                    new XElement("Quantity", item.Quantity),
                    new XElement("Sell", item.Sell)
                    );
            root.Add(xml);
        }
        Game.Model.Deck decks = new Game.Model.Deck();
        //decks.SaveXml("writetest.xml", root);
