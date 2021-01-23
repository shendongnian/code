    public class DamagedItem 
    {
      public DamagedItem() 
      {
        DamagedItems = new List<DamagedItems>();
        DamagedItems.Add(new DamagedItem { Description = "Damaged" } );
      }
        
      public Int32 LoanId {get;set;}
      public String IdentityCode {get;set;}
      public virtual ICollection<DamagedItems> DamagedItems {get;set;}
    }
