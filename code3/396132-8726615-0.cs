    public interface IAuditEntity
    {
        User CreateUsr { get; set;}
        DateTime OperationTime { get; set;}
        User LastOperationUser { get; set;}
    }
     public void UpdateEntityObjectsCommonFields(IAuditEntityobj) 
     {  /// just i guess
        obj.CreateUsr  = Session.Usr;
        obj.OperationTime  = DateTime.Now;
        obj.LastOperationUser  = Session.Usr;
     }
