    static void Main(string[] args)
    {
        // directory with known ACL problem (created using Icacls)
    	DirectoryInfo directoryInfo = new DirectoryInfo("acltest");
    
    	var directorySecurity = directoryInfo.GetAccessControl(AccessControlSections.Access);
    	CanonicalizeDacl(directorySecurity);
    	directoryInfo.SetAccessControl(directorySecurity);
    }
    
    static void CanonicalizeDacl(NativeObjectSecurity objectSecurity)
    {
    	if (objectSecurity == null) { throw new ArgumentNullException("objectSecurity"); }
    	if (objectSecurity.AreAccessRulesCanonical) { return; }
    
    	// A canonical ACL must have ACES sorted according to the following order:
    	//   1. Access-denied on the object
    	//   2. Access-denied on a child or property
    	//   3. Access-allowed on the object
    	//   4. Access-allowed on a child or property
    	//   5. All inherited ACEs 
    	RawSecurityDescriptor descriptor = new RawSecurityDescriptor(objectSecurity.GetSecurityDescriptorSddlForm(AccessControlSections.Access));
    
    	List<CommonAce> implicitDenyDacl = new List<CommonAce>();
    	List<CommonAce> implicitDenyObjectDacl = new List<CommonAce>();
    	List<CommonAce> inheritedDacl = new List<CommonAce>();
    	List<CommonAce> implicitAllowDacl = new List<CommonAce>();
    	List<CommonAce> implicitAllowObjectDacl = new List<CommonAce>();
    
    	foreach (CommonAce ace in descriptor.DiscretionaryAcl)
    	{
    		if ((ace.AceFlags & AceFlags.Inherited) == AceFlags.Inherited) { inheritedDacl.Add(ace); }
    		else
    		{
    			switch (ace.AceType)
    			{
    				case AceType.AccessAllowed:
    					implicitAllowDacl.Add(ace);
    					break;
    
    				case AceType.AccessDenied:
    					implicitDenyDacl.Add(ace);
    					break;
    
    				case AceType.AccessAllowedObject:
    					implicitAllowObjectDacl.Add(ace);
    					break;
    
    				case AceType.AccessDeniedObject:
    					implicitDenyObjectDacl.Add(ace);
    					break;
    			}
    		}
    	}
    
    	Int32 aceIndex = 0;
    	RawAcl newDacl = new RawAcl(descriptor.DiscretionaryAcl.Revision, descriptor.DiscretionaryAcl.Count);
    	implicitDenyDacl.ForEach(x => newDacl.InsertAce(aceIndex++, x));
    	implicitDenyObjectDacl.ForEach(x => newDacl.InsertAce(aceIndex++, x));
    	implicitAllowDacl.ForEach(x => newDacl.InsertAce(aceIndex++, x));
    	implicitAllowObjectDacl.ForEach(x => newDacl.InsertAce(aceIndex++, x));
    	inheritedDacl.ForEach(x => newDacl.InsertAce(aceIndex++, x));
    
    	if (aceIndex != descriptor.DiscretionaryAcl.Count)
    	{
    		System.Diagnostics.Debug.Fail("The DACL cannot be canonicalized since it would potentially result in a loss of information");
    		return;
    	}
    
    	descriptor.DiscretionaryAcl = newDacl;
    	objectSecurity.SetSecurityDescriptorSddlForm(descriptor.GetSddlForm(AccessControlSections.Access), AccessControlSections.Access);
    }
