		/// <summary> Checks for write access for the given file.
		/// </summary>
		/// <param name="fileName">The filename.</param>
		/// <returns>true, if write access is allowed, otherwise false</returns>
		public static bool WriteAccess(string fileName)
		{
			if ((File.GetAttributes(fileName) & FileAttributes.ReadOnly) != 0)
				return false;
			
			// Get the access rules of the specified files (user groups and user names that have access to the file)
			var rules = File.GetAccessControl(fileName).GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
			// Get the identity of the current user and the groups that the user is in.
			var groups = WindowsIdentity.GetCurrent().Groups;
			string sidCurrentUser = WindowsIdentity.GetCurrent().User.Value;
			// Check if writing to the file is explicitly denied for this user or a group the user is in.
			if (rules.OfType<FileSystemAccessRule>().Any(r => (groups.Contains(r.IdentityReference) || r.IdentityReference.Value == sidCurrentUser) && r.AccessControlType == AccessControlType.Deny && (r.FileSystemRights & FileSystemRights.WriteData) == FileSystemRights.WriteData))
				return false;
			// Check if writing is allowed
			return rules.OfType<FileSystemAccessRule>().Any(r => (groups.Contains(r.IdentityReference) || r.IdentityReference.Value == sidCurrentUser) && r.AccessControlType == AccessControlType.Allow && (r.FileSystemRights & FileSystemRights.WriteData) == FileSystemRights.WriteData);
		}
