    public class User {
      public virtual int UserId { get; protected set; }
      public virtual string Name { get; set; }
      public virtual Dictionary<Resource, string> Resources { get; set; } // Resource -> AccessLevel
    }
    
    public class UserMap : ClassMap<User> {
    
      public UserMap() {
    
        Table("User");
        Id(x => x.UserId);
        Map(x => x.Name);
        HasMany<Resource, string>(x => x.Resources).AsEntityMap().Element("AccessLevel");
      }
    }
