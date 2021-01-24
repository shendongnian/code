 c#
[XmlRoot("root")]
public class Data
{
    [XmlElement("data")]
    public OptionsData Options { get; set; }
}
public class OptionsData
{
    [XmlAttribute("label")]
    public string Label { get; set; }
    [XmlAttribute("min")]
    public string Min { get; set; }
    [XmlAttribute("max")]
    public string Max { get; set; }
    [XmlElement("option")]
    public List<GeneralOptions> Items { get; } = new List<GeneralOptions>();
}
public class GeneralOptions
{
    [XmlElement("id")]
    public string Id { get; set; }
    [XmlElement("name")]
    public string Name { get; set; }
}
