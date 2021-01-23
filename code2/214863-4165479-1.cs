    class User
    {
       public int UserID { get; internal set; }
       public string UserName { get; set; }
       public delegate Role[] GetRolesDelegate(int userId, string username);
       public GetRolesDelegate GetRoles { get; set; }
       Role[] _roles;
       public Role[] Roles
       {
          get
          {
              if (_roles == null)
              {
                  _roles = GetRoles == null 
                      ? new Role { } 
                      : GetRoles(UserID, UserName).ToEntityArray();
              }
              return _roles;
          }
       }
    }
