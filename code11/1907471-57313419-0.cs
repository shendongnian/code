    [DataContract(Namespace = "http://xyz")]
    public class ApplicationRequestImpl
    {
    	[DataMember]
        public Application Application;
    
        //[DataMember(Name="Application_SAList")]
        //public ApplicationSASingle Application_SAList;
    
    	[DataMember]
        public Application_SA[] Application_SAList;
    }
