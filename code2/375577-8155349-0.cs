    public class Customer
    {
       ...
       public string Name
       {
          get;
          private set;
       }
    
       public void SetName(object callingControl, string newName)
       {
          if(callingControl!=null && callingControl is CustomerUserControl)
             this.Name = newName;
       }
       ...
    }
