    public class User
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public User()
            {
    
            }
            public static User CreateUser()
            {
                return new User();
            }
            public static User CreateUser(string name, string lastName)
            {
                return new User
                {
                    Name = name,
                    LastName = lastName
                };
            }
        }
