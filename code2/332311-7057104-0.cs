    protected bool HasPermission(long ObjectId, string RoleName)
    {
	//Users in the Administrator role have access to everything in the system.
	if (this.IsAdministrator) {
		HasPermission = true;
		return;
	}
	foreach (Permission P in Permissions) {
		if (P.ObjectID == ObjectID & P.RoleName == Role) {
			HasPermission = true;
			return;
		}
	}
	return false;
    }
