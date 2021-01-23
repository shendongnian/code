    public struct Declarations
    {
        public const string SchemaVersion_DEV
            = "http://localhost:4304/XMLSchemas/Request.xsd";
        public const string SchemaVersion_STE
            = "http://someotherserver/XMLSchemas/Request.xsd";
        public const string SchemaVersion_UAT
            = "http://anotherserver/XMLSchemas/Request.xsd";
    }
    
    #if DEV
    [XmlRoot(ElementName = "Header", Namespace = Declarations.SchemaVersion_DEV, IsNullable = false), Serializable]
    #elif STE
    [XmlRoot(ElementName = "Header", Namespace = Declarations.SchemaVersion_STE, IsNullable = false), Serializable]
    #elif UAT
    [XmlRoot(ElementName = "Header", Namespace = Declarations.SchemaVersion_UAT, IsNullable = false), Serializable]
    #endif
    public class RequestHeader { }
