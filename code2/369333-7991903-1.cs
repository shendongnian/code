    spWeb.SiteGroups.Add(groupName, user, user, groupDescription);
    SPGroup newGroup = spWeb.SiteGroups[groupName];
    SPRoleAssignment roleAssignment = new SPRoleAssignment(newGroup);
    //add role to web
    spWeb.RoleAssignments.Add(roleAssignment);
    spWeb.Update();
