    public class PersonMap : ClassMap<Person>
    {
      public PersonMap()
      {
        Table("Persons");
        Id(x =>x.Id, "PersonId").GeneratedBy.Identity();
        References(x => x.User).Column("UserId").Cascade.All();
        Map(x => x.FirstName, "FirstName");
        Map(x => x.LastName, "LastName");
        Map(x => x.Address, "Address");
        Map(x => x.Phone, "Phone");
        // More property maps
      }
    }
    
    public class UserMap : ClassMap<User>
    {
      public UserMap()
      {
        Id(x => x.Id, "UserId").GeneratedBy.Identity();
        Map(x => x.Username, "Username");
        Map(x => x.Password, "Password");
        References<Person>(x => x.PrimaryPerson).ForeignKey("PrimaryPersonId").Cascade.All();
      }
    }
