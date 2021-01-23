    // Open the web directly since it is a direct child of the site collection.
    // Use a using to properly release the resources
    using (SPWeb web = spSite2.Open("templates"))
    {
      SPUser user = web.SiteUsers[appUserAccount];
      SPRoleDefinition roleDef = web.RoleDefinitions.GetByType(SPRoleType.Reader);
	
      if (!web.HasUniqueRoleAssignments)
      {
        web.BreakRoleInheritance(true);
      }
		
      spRoleAssignment = new SPRoleAssignment(user);
      spRoleAssignment.RoleDefinitionBindings.Add(roleDef);
      web.RoleAssignments.Add(spRoleAssignment);
	
      // No need to update the web when changing the permissions
    }
