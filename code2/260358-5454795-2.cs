	using (var user = WindowsIdentity.GetCurrent())
	{
		var ownerSecurity = new FileSecurity();
		ownerSecurity.SetOwner(user.User);
		File.SetAccessControl("c:\\path\\to\\broken", ownerSecurity);
		var accessSecurity = new FileSecurity();
		accessSecurity.AddAccessRule(new FileSystemAccessRule(user.User, FileSystemRights.FullControl, AccessControlType.Allow));
		File.SetAccessControl("c:\\path\\to\\broken", accessSecurity);
	}
