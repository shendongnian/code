    // Junction Table
    public class Requests
    {
       [Key]
       public int Id {get; set;}
       public int createdAt {get; set;}
       
       [ForeginKey("RequestType")]
       public int RequestTypeId {get; set;}
       public virtual RequestType RequestType {get; set;}
       
       [ForeginKey("MasterSections")]
       public int MasterSectionID {get; set;}
       public virtual MasterSections MasterSections {get; set;}
       
       public int RequestStatusID {get; set;}
       
       [ForeginKey("RequestStage")]
       public int RequestStageID {get; set;}
       public virtual RequestStage RequestStage {get; set;}
    }
    
    public class RequestStage
    {
       [Key]
       public int RequestStageID {get; set;}
       public string name {get; set;}
    }
    
    public class MasterSections
    {
       public int MasterSectionId {get; set;}
       public string name {get; set;}
    }
    
    public class LocalCodes
    {
       [Key]
       public int Id {get; set;}
       
       [ForeginKey("MasterSections")]
       public int MasterSectionId {get; set;}
       public virtual MasterSections MasterSections {get; set;}
       public string Description {get; set;}
       public string name {get; set;}
    }
