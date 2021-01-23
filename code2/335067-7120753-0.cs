    class Program
    {
        static void Main(string[] args)
        {
            var newState1 = new User
                            {
                                UserId = 1,
                                UserName = "Lee",
                                NumViews = 1,
                                Profile = new UserProfile
                                          {
                                              FirstName = "Lee",
                                              LastName = "Timmins"
                                          },
                                RoleMember = new Role {RoleId = 1, RoleName = "User"}
                            };
            
            // True - since Username has changed
            var newState2 = new User
                            {
                                UserId = 1,
                                UserName = "Lee2",
                                NumViews = 1,
                                Profile = new UserProfile
                                          {
                                              FirstName = "Lee",
                                              LastName = "Timmins"
                                          },
                                RoleMember = new Role {RoleId = 1, RoleName = "User"}
                            };
            //Will show 1 or -1 if not state has change. If == 0 then state has not changed.
            Console.WriteLine("Has State1 Changed? : {0}", newState1.CompareTo(newState2));
            Console.ReadLine();
        }
        public class User : IComparable<User>
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public int NumViews { get; set; }
            public UserProfile Profile { get; set; }
            public Role RoleMember { get; set; }
            #region Implementation of IComparable<in User>
            public int CompareTo(User other)
            {
                if (UserId.CompareTo(other.UserId) != 0)
                {
                    return UserId.CompareTo(other.UserId);
                }
                if (UserName.CompareTo(other.UserName) != 0)
                {
                    return UserName.CompareTo(other.UserName);
                }
                if (NumViews.CompareTo(other.NumViews) != 0)
                {
                    return NumViews.CompareTo(other.NumViews);
                }
                if (Profile.CompareTo(other.Profile) != 0)
                {
                    return Profile.CompareTo(other.Profile);
                }
                return RoleMember.CompareTo(other.RoleMember) != 0 ? RoleMember.CompareTo(other.RoleMember) : 0;
            }
            #endregion
        }
        public class UserProfile : IComparable<UserProfile>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            #region Implementation of IComparable<in UserProfile>
            public int CompareTo(UserProfile other)
            {
                return FirstName.CompareTo(other.FirstName) == 0 ? LastName.CompareTo(other.LastName) : FirstName.CompareTo(other.FirstName);
            }
            #endregion
        }
        public class Role : IComparable<Role>
        {
            public int RoleId { get; set; }
            public string RoleName { get; set; }
            #region Implementation of IComparable<in Role>
            public int CompareTo(Role other)
            {
                return RoleId.CompareTo(other.RoleId) == 0 ? RoleName.CompareTo(other.RoleName) : RoleId.CompareTo(other.RoleId);
            }
            #endregion
        }
    }
