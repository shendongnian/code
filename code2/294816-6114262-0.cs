    [ProtoContract]
    [Serializable]
    public class Web2PdfClient : Web2PdfEntity
    {
    
    }
    
    [ProtoContract]
    [ProtoInclude(7, typeof(Web2PdfClient))]
    [Serializable]
    public class Web2PdfEntity : EngineEntity
    { ... }
