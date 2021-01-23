    [DataContract]
    class JSONResponse {
    	[DataMember]
    	public string status {get;set;}
    	[DataMember]
    	public string node {get;set;}
    	[DataMember]
    	public string type {get;set;}
    	[DataMember]
    	public Hashtable<Result> result {get;set;}
    }
    [DataContract]
    class Result {
    	[DataMember]
    	public string tx.mqid {get;set;}
    	[DataMember]
    	public string tx.time {get;set;}
    	[DataMember]
    	public string tx.id {get;set;}
    }
