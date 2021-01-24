    [DataContract(Namespace = "http://xyz")]
    public class ApplicationRequestImpl
    {
    	[DataMember]
        public Application Application;
    
        //Remove these two lines
        //[DataMember(Name="Application_SAList")]
        //public ApplicationSASingle Application_SAList;
    
    	[DataMember]
        public Application_SA[] Application_SAList;
    }
