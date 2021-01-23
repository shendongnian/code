    //As an abstract base class
    public void SetupRoles(RoleProvider provider){}
    
    //As an interface
    public void SetupRoles(IRoleProvider provider){}
    
    //As a delegate
    public void SetupRoles(Action<String> addRole){}
