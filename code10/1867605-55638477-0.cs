	public UserHasReadPermission(string username, string file)
	{
		var user = new UnixUserInfo(username);
    	var file = new UnixFileInfo(file);
		// Everyone has read permission
		if (file.FileAccessPermissions.HasFlag(FileAccessPermissions.OtherRead))
			return true;
		// User owns the file and has read permission
		if (file.OwnerUser == user && file.FileAccessPermissions.HasFlag(FileAccessPermissions.UserRead))	
			return true;
			
		// User group owns the file and has read permission
		if (file.OwnerGroup == user.Group && file.FileAccessPermissions.HasFlag(FileAccessPermissions.GroupRead))	
			return true;
		return false;
	}
