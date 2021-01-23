    var Roles = new string[] { "e8b08a45-9cb5-4ac9-8c6c-9dfe4ac23966$Moderator" };
    Dictionary<string, RolePrivilege> Role = PrivilegeProxy.GetPrivilegesForRoles("744A2BE3-846E-4E4A-9796-DAF9C743E8FF", Roles);
    Dictionary<string, Privilege> Privilege = PrivilegeProxy.GetPrivilegesbyModuleIds(new string[] { "Groups" });
    var identicalQuery = from roles in Role
                         join privileges in Privilege on roles.Value.PrivilegeName equals privileges.Value.Name
                         select new { Roles = roles, Privileges = privileges };
     
	Dictionary<string, Privilege> Result = identicalQuery.ToDictionary(_ => _.Roles.Key, _.Privileges.Value);
 
