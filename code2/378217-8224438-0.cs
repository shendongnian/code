    XmlAttributeOverrides or = new XmlAttributeOverrides();
    or.Add(typeof(ChannelConfiguration), new XmlAttributes
    {
        XmlType = new XmlTypeAttribute("Channel")
    });
    var xmlSerializer = new XmlSerializer(typeof(List<ChannelConfiguration>), or,
         Type.EmptyTypes, new XmlRootAttribute("Channels"), "");
    xmlSerializer.Serialize(Console.Out,
         new List<ChannelConfiguration> { new ChannelConfiguration { } });
