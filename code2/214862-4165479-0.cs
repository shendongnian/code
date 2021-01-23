    class User
    {
       public int UserID { get; internal set; }
       public string UserName { get; set; }
       public delegate Role[] GetRolesDelegate(int userId, string username);
       public GetRolesDelegate GetRoles { get; set; }
       public Role[] Roles
       {
          get
          {
             return GetRoles == null 
                 ? new Role { } 
                 : GetRoles(UserID, UserName).ToEntityArray();
          }
       }
    }
