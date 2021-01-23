    //note: using SiteGroups is "safer",
    //because also groups which don't yet have any permissions are included
    SPGroup spGroup = spWeb.SiteGroups["MyGroup"];
    SPRoleDefinition spRole = spWeb.RoleDefinitions["Read"]; 
    
    SPRoleAssignment roleAssignment= new SPRoleAssignment(spGroup);
    roleAssignment.RoleDefinitionBindings.Add(spRole);
    
    SPListItem listItem = spWeb.GetListItem("http://<URL to item somewhere on the Site>");
    listItem.BreakRoleInheritance(true);
    listItem.RoleAssignments.Add(roleAssignment);
    listItem.Update();
