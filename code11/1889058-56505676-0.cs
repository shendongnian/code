    var user = new User()
    {
       Username = "User 1",
       Password = "***",
       Usergroups = new List<Usergroup>()
       {
          new Usergroup()
          {
            Name = "Administrator",
            Screen = new Screen() { Name = "Users" },
            AccessRights = new List<AccessRight>()
            {
                new AccessRight() { AccessLevel = 9999 }
            },
            Users = new List<User>()
            {
                new User()
                {
                    Password = "@#$%",
                    Usergroups = new List<Usergroup>(),
                    Username = "User 2"
                }
            }
        }
       }
    };
    //Here you serialize your object.
    var json = JsonConvert.SerializeObject(user);
