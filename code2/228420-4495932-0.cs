    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
	    {
		    Id(x => x.Id)...
		    ...
		    References(x => x.User).Inverse(); // User references Person
	    }
    }
    public class UserMap : ClassMap<User>
    {
        public UserMap()
	    {
		    Id(x => x.Id)...
		    ...
		    References(x => x.PrimaryPerson).Column("PrimaryPersonId")...
		    HasMany(x => x.People).KeyColumn("UserId").Inverse(); // UserId is on the Person
	    }
    }
