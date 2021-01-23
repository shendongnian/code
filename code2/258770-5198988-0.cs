    public interface Deletable
    {
      DateTime DeletionDate{get;set;}
      bool Deleted{get;}
    }
    
    public class DeletableImpl : Deletable
    {
      public DateTime DeletionDate{get; set;}
      public bool Deleted{get {return DeletionDate != default(DateTime);}}
    }
    // Do the same thing with Modifiable and ModifiableImpl
    
    public class Something : Deletable, Modifiable
    {
      private Deletable _deletable = new DeletableImpl();
      private Modifiable _modifiable = new ModifiableImpl();
      public DateTime DeletionDate
      {
        get{return _deletable.DeletionDate;}
        set{_deletable.DeletionDate = value;}
      }
      public bool Deleted{get{return _deletable.Deleted;}}
      public DateTime ModifiedDate {
        // and so on as above
    }
 
