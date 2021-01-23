public class Route
{
    [XmlAttribute("No")]
    public int Number { get {return "1108";} }
    public Name Name { get; set; }
    public City City { get; set; }
}
public class Name
{
    [XmlAttribute("No")]
    public int Number { get {return "60";} }
    [XmlText]
    public string Value { get; set; }
}
public class City
{
    [XmlAttribute("No")]
    public int Number { get {return "70";} }
    [XmlText]
    public string Name { get; set; }
}
