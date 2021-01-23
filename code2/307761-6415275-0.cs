    public class BrowsableAttribute : Attribute
    {
      public bool IsBrowsable { get; protected set; }
      public BrowsableAttribute(bool isBrowsable)
      {
        this.IsBrowsable = isBrowsable;
      }
    }
    
    public enum DomainTypes  
    {  
        [Browsable(true)]  
         Client = 1,  
        [Browsable(false)]  
        SecretClient = 2,    
    } 
