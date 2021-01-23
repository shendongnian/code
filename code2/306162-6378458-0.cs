    public bool IsRunningAsLocalAdmin()
    {
    	WindowsIdentity cur = WindowsIdentity.GetCurrent();
    	foreach (IdentityReference role in cur.Groups) {
    		if (role.IsValidTargetType(typeof(SecurityIdentifier))) {
    			SecurityIdentifier sid = (SecurityIdentifier)role.Translate(typeof(SecurityIdentifier));
    			if (sid.IsWellKnown(WellKnownSidType.AccountAdministratorSid) || sid.IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid)) {
    				return true;
    			}
    
    		}
    	}
    
    	return false;
    }
