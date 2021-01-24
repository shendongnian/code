    public class Owner
    {
      public int Id;
      public string Name;
      public virtual ICollection<Phone> Phones;
      public abstract SendMessage(Phone phone);
    }
    
    public class Person : Owner 
    {
      public override SendMessage(Phone phone)
      {
       ...
      }
    
    }
    public class Shop : Owner 
    {
      public override SendMessage(Phone phone)
      {
       ...
      }
    }
    
    public class Phone {
      public int Id;
      public string AreaCode;
      public string Number;
    
      public int? OwnerId;
      public virtual Owner Owner;
    }
