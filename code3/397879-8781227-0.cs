    [OperationContract]
    [CorsBehavior]
    [WebInvoke(Method = "PUT", UriTemplate = "Graphs/{library}/triple")]
    ResultMessage CreateTriple(string library, TripleModel model);
    
    [DataContract]
    public class TripleModel {	
    	[DataMember]
    	public string SubjectLocalPart { get; set; }
    	
    	[DataMember]
    	public string PredicateLocalPart { get; set; }
    	
    	[DataMember]
    	public string ObjectPart { get; set; }
    	
    	[DataMember]
    	public string LanguageCode { get; set; }
    }
