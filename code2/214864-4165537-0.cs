    class User
    {
       public int UserID { get; internal set; }
       public string UserName { get; set; }
       private Role[] _roles;
    
       public Role[] Roles
       {
          get
          {
             if (_roles != null)
             {    
    
                 if (this.UserID > 0)
                    _roles = RoleRepository.GetByUserID(this.UserID).ToEntityArray();
                 else
                    _roles = RoleRepository.GetByUserName(this.UserName).ToEntityArray();
             }
             
             return _roles;
          }
       }
    }
