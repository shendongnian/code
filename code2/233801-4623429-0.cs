    public class Base 
    {     
      private readonly List<UserActions> _list;      
      
      protected Base(IEnumerable<UserActions> values)
      {         _list = new List<UserActions>(values);  
      } 
    }  
    public class Derived : Base 
    {     
       public Derived() : base((UserActions[]) Enum.GetValues(typeof(UserActions))
      { 
      }
    } 
