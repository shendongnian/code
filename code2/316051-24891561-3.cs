    // For that you will need to add reference to System.Runtime.Serialization
    var jsonReader = JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(@"{ ""Name"": ""Jon Smith"", ""Address"": { ""City"": ""New York"", ""State"": ""NY"" }, ""Age"": 42 }"), new System.Xml.XmlDictionaryReaderQuotas());
    // For that you will need to add reference to System.Xml and System.Xml.Linq
    var root = XElement.Load(jsonReader);
    Console.WriteLine(root.XPathSelectElement("//Name").Value);
    Console.WriteLine(root.XPathSelectElement("//Address/State").Value);
    // For that you will need to add reference to System.Web.Helpers
    dynamic json = System.Web.Helpers.Json.Decode(@"{ ""Name"": ""Jon Smith"", ""Address"": { ""City"": ""New York"", ""State"": ""NY"" }, ""Age"": 42 }");
    Console.WriteLine(json.Name);
    Console.WriteLine(json.Address.State);
