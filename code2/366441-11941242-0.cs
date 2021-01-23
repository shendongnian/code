    // Set the list to return and get the group we are looking through.
    List<UserPrincipal> list = new List<UserPrincipal>();
    GroupPrincipal group = GroupPrincipal.FindByIdentity(new PrincipalContext(/* connection info here */), ((groupName.Length > 0) ? groupName : this.Properties.Name));
    
    // For each member of the group add all Users.
    foreach (Principal princ in group.Members)
    {
        /*
        To change what you are looking for or how you are looking for it, 
        simply change some of the following conditions to match what you want.
        */
        
        // If this member is a User then add them.
        if (princ.StructuralObjectClass == "user")
        {
            list.Add(UserPrincipal.FindByIdentity(new PrincipalContext(/* connection info here */), princ.Name);
        }
        
        // If we are looking recursively and this member is a GL_Group then get the Users in it and add them.
        if (recursive && (princ.StructuralObjectClass == "group") && (((GroupPrincipal)princ).GroupScope == GroupScope.Global))
        {
            list.AddRange(this.GetUsers(true, princ.Name));
        }
    }
    return list;
