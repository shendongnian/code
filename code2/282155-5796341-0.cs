    [System.Xml.Serialization.XmlElementAttribute(ElementName="InformationResponse")]
    [System.Xml.Serialization.XmlInclude(typeof(Policy))]
    public class InformationResponse : List<Policy>
    {  
        ...
    }  
