    [System.Xml.Serialization.XmlRootAttribute("InformationResponse", ElementName="InformationResponse")]
    [System.Xml.Serialization.XmlInclude(typeof(Policy))]
    public class InformationResponse : List<Policy>
    {  
        ...
    }  
