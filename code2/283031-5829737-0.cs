    public class UniqueUserNameSpecification : ISpecification
    {
      public bool IsSatisifiedBy(User user)
      {
         // Check if the username is unique here
      }
    }
    public class User
    {
       string _Name;
       UniqueUserNameSpecification _UniqueUserNameSpecification;  // You decide how this is injected 
    
       public string Name
       {
          get { return _Name; }
          set
          {
            if (_UniqueUserNameSpecification.IsSatisifiedBy(this))
            {
               _Name = value;
            }
            else
            {
               // Execute your custom warning here
            }
          }
       }
    }
