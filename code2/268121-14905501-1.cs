    public class UserMap : ClassMap<User>
        {
            public UserMap()
            {
                Table("user");
                
                // Reveal private attributes and map them
                Id(Reveal.Member<User>("_id")).Column("id");
                Map(Reveal.Member<User>("_username")).Column("username");
                Map(Reveal.Member<User>("_openid")).Column("openid_claimed_identifier");
                Map(Reveal.Member<User>("_email")).Column("email");
    
                // You need to create this mapping if you want to query using linq, 
                //see UserRepository below
                Map(x => x.Id, "id").ReadOnly();
                Map(x => x.Email, "email").ReadOnly();
                Map(x => x.Username, "username").ReadOnly();
                Map(x => x.Openid, "openid_claimed_identifier").ReadOnly();
            }
        }
