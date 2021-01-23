    [DataContract]
    public class YourReturnObject {
      [DataMember(Name="query")]
      public String Query { get;set;}
    
      [DataMember(Name="suggestions")]
      public String[] Suggestions { get;set;}  
    
      [DataMember(Name="data")]
      public String[] OtherData{ get;set;} 
    }
