        class UserSurrogate : User
        {
            public static explicit operator UserSurrogate(MemberShipUser other)
            {
                return  new UserSurrogate() { Name = other.Name };
            }
        }
        class User
        {
            public string Name { get; set; }
        }
        class MemberShipUser
        {
            public string Name { get; set; }   
        }
