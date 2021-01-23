    using (var context = new PrincipalContext(ContextType.Domain, "domainName"))
    {
        using (var group = GroupPrincipal.FindByIdentity(context, "groupName"))
        {
            if (group == null)
            {
                MessageBox.Show("Group does not exist");
            }
            else
            {
                var users = group.GetMembers(true);
                foreach (UserPrincipal user in users)
                {
                     //user variable has the details about the user 
                }
            } 
        }
    }
