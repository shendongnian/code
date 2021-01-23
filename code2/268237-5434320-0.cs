    public class Contract
    {
       public virtual string ContractId { get; set; }
       public virtual ICollection<ContractPart> ContractParts { get; set; }
    }
    
    public class Part
    {
       public virtual string PartId { get;set; }
       public virtual ICollection<ContractPart> ContractParts { get; set; }
    }
    
    public class ContractPart
    { 
       public virtual ContractId { get; set; }
       public virtual PartId { get; set; }
       public virtual Contract { get; set; }
       public virtual Part { get; set; }
       public virtual Date { get; set; } //additional info
       public virtual Price { get; set; } //additional info
    }
