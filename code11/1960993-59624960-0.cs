    [DataContract(Namespace = "")]
    
    class Record {
    
    [DataMember]
    
    public string Id { get; set; }
    
    }
    
       
    Record recordDefault = new Record { Id = "default Record" };
    
    BrokeredMessage recordDefaultMessage = new BrokeredMessage(recordDefault);
