// Setting the default settings is the only way I know to affect settings
// for DeserializeXmlNode, there may be a better way
Newtonsoft.Json.JsonConvert.DefaultSettings = 
    () => new Newtonsoft.Json.JsonSerializerSettings() { 
    DateParseHandling = Newtonsoft.Json.DateParseHandling.None };
# Test
var json = @"
{
    ""Flight"": {
        ""FlightNumber"": ""747"",
        ""Source"": ""JFK"",
        ""Destination"": ""LAS"",   
        ""Status"": ""ON TIME"",
        ""DepDateTime"": ""2019-10-25T07:00:00-05:00"",
        ""Terminal"": ""2""
    }
}            
";
Newtonsoft.Json.JsonConvert.DefaultSettings = () => new Newtonsoft.Json.JsonSerializerSettings() { DateParseHandling = Newtonsoft.Json.DateParseHandling.None };
System.Xml.XmlDocument xmlDoc = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(json);
Console.WriteLine(xmlDoc.InnerXml);
# Output
(...)<DepDateTime>2019-10-25T07:00:00-05:00</DepDateTime><Terminal>2</Terminal></Flight>
## Output without setting the settings
(...)<DepDateTime>2019-10-25T22:00:00+10:00</DepDateTime><Terminal>2</Terminal></Flight>
