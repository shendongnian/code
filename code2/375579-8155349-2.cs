    public class Customer
    {
       ...
       public string Name
       {
          get;
          private set;
       }
    
       public void SetName(string callingControlName, string newName)
       {
          // you'd use TypeOf the same way to pass in callingControlName
          if(TypeOf(this).Name + "UserControl" == callingControlName)
             this.Name = newName;
       }
       ...
    }
