c#
public class ReportParameterOfInt32 : ReportParameter
{
    int _value;
    [XmlIgnore]
    public new int Value
    {
        get { return _value; }
        set
        {
            base.Value = value;
            _value = value;
        }
    }
}
public class ReportParameterOfDateTime : ReportParameter
{
    DateTime _value;
    [XmlIgnore]
    public new DateTime Value
    {
        get { return _value; }
        set
        {
            base.Value = value;
            _value = value;
        }
    }
}
Updated the `ReportParameters` (which I guessed how it looks like since it wasn't provided in code):
c#
public class ReportParameters
{
    [XmlArrayItem(typeof(ReportParameterOfInt32))]
    [XmlArrayItem(typeof(ReportParameterOfDateTime))]
    public ReportParameter[] Parameters { get; set; }
}
Simplified the Serializer and wrote the Deserializer:
c#
private static string Serialize(this ReportParameters parameters)
{
    XmlSerializer xsSubmit = new XmlSerializer(typeof(ReportParameters));
    string xml = string.Empty;
    using (var sww = new StringWriter())
    {
        using (var writer = XmlWriter.Create(sww))
        {
            xsSubmit.Serialize(writer, parameters);
            xml = sww.ToString();
            return xml;
        }
    }
}
private static ReportParameters Deserialize(string xml)
{
    XmlSerializer xsSubmit = new XmlSerializer(typeof(ReportParameters));
    using (var reader = new StringReader(xml))
    {
        return (ReportParameters)xsSubmit.Deserialize(reader);
    }
}
Wrote the test code which then executed as expected:
c#
var xml = Serialize(
    new ReportParameters
    {
        Parameters = new ReportParameter[]
        {
            new ReportParameterOfInt32 { Name = "Test", Value = 4 },
            new ReportParameterOfDateTime { Name = "Startdate", Value = new DateTime(2019, 04, 05, 22, 52, 25) }
        }
    });
var obj = Deserialize(xml);
I know you might feel a little dissapointed, however, I do think that you can just use wrappers to ensure that it writes to the underlying type correctly without having to serialize the Generic type which should hopefully satisfy your "SQL Injection" requirement but you still will have an issue with strings. You need to ensure that you escape any characters that will make SQL injection possible.
