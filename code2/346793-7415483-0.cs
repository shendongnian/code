    public class GrantApplication : IEntity
    {
       public int Id { get; set; }
    
       public int MaritalStatusTypeId { get; set; }
       public virtual MaritalStatusType MaritalStatusType { get; set; }
    }
