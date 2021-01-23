    [ServiceContract(Namespace = "http://tesmpuri.com/")]
    [ServiceKnownType(typeof(Video))]
    public interface IPartialResponseTestService
    {
    	[OperationContract]
    	Video GetFullVideo();
    
    	[OperationContract]
    	[CustomDataContractFormat]
    	Video GetPartVideo(params string[] fields);
    
    	[OperationContract]
    	[XmlSerializerFormat]
    	Video GetVideo();
    }
