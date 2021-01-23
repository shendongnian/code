    var security = Directory.GetAccessControl(folderPath);
    security.AddAccessRule(
    	new FileSystemAccessRule(
    		new SecurityIdentifier(WellKnownSidType.NetworkServiceSid, null),
    		FileSystemRights.Modify,
    		InheritanceFlags.ObjectInherit,
    		PropagationFlags.InheritOnly,
    		AccessControlType.Allow
    	)
    );
    Directory.SetAccessControl(folderPath, security);
