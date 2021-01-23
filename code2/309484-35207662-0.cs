			RegistryKey rkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Norton\SecurityStatusSDK", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.ChangePermissions);
			if (rkey == null)
				throw new Exception("Not Open");
			//-------
			RegistrySecurity _registrySecurity = new RegistrySecurity();//Or rkey.GetAccessControl();
			WindowsIdentity _windowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
			RegistryAccessRule _accessRule = new RegistryAccessRule(_windowsIdentity.Name, RegistryRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow);
			_registrySecurity.AddAccessRule(_accessRule);
			_registrySecurity.SetAccessRuleProtection(false, true);
			try
			{
				rkey.SetAccessControl(_registrySecurity);// <---"Attempted to perform an unauthorized operation."
			}
			catch (UnauthorizedAccessException e)
			{
			}
			//--------Now, Set owner
			_registrySecurity.SetGroup(new NTAccount("Administrators"));  //This is optional
			var SID = new System.Security.Principal.NTAccount("XXX\\Users");
			_registrySecurity.SetOwner(SID);
			rkey.SetAccessControl(_registrySecurity);
