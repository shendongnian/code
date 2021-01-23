	using (var user = WindowsIdentity.GetCurrent())
	{
		var ownerSecurity = new DirectorySecurity();
		ownerSecurity.SetOwner(user.User);
		Directory.SetAccessControl("c:\\path\\to\\broken", ownerSecurity);
		var accessSecurity = new DirectorySecurity();
		accessSecurity.AddAccessRule(new FileSystemAccessRule(user.User, FileSystemRights.FullControl, AccessControlType.Allow));
		Directory.SetAccessControl("c:\\path\\to\\broken", accessSecurity);
	}
