    using Newtonsoft.Json;
    
    [XmlRoot("ObjectSummary")]
    public class Summary
    {
         public string Name {get;set;}
         public string IsValid {get;set;}
    }
     //pass objectr of Summary class you want to convert to XML
     var json = JsonConvert.SerializeObject(obj);
     XNode node = JsonConvert.DeserializeXNode(json, "ObjectSummary");
