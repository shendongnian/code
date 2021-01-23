    public class Persons<T>
    {
       public virtual void InputPerson(T p)
       {
     // code here.
       }
    }
    
    public class User : Person<User>
    {
     public override void InputPerson(User p)
     {
      // code here. You can now treat the input as a user
      // as you have told your base class that the 'T' is a user.
     }
    }
