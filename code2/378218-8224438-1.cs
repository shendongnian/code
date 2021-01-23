    [XmlType("Channel")]
    public class ChannelConfiguration
    {...}
    var xmlSerializer = new XmlSerializer(typeof(List<ChannelConfiguration>),
         new XmlRootAttribute("Channels"));
    xmlSerializer.Serialize(Console.Out,
         new List<ChannelConfiguration> { new ChannelConfiguration { } });
