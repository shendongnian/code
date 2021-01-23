	// pCurrentClass can be NULL in the case of a global function
	// pCurrentClass it the point from which we're trying to access something
	// pTargetClass is the class containing the member we are trying to access
	// dwMemberAccess is the member access within pTargetClass of the member we are trying to access
	BOOL ClassLoader::CheckAccess(EEClass *pCurrentClass,
								  Assembly *pCurrentAssembly,
								  EEClass *pTargetClass,
								  Assembly *pTargetAssembly,
								  DWORD dwMemberAccess)
	{
		// we're trying to access a member that is contained in the class pTargetClass, so need to 
		// check if have access to pTargetClass itself from the current point before worry about 
		// having access to the member within the class
		if (! CanAccessClass(pCurrentClass,
							 pCurrentAssembly, 
							 pTargetClass, 
							 pTargetAssembly))
			return FALSE;
		if (IsMdPublic(dwMemberAccess))
			return TRUE;
	    
		// This is module-scope checking, to support C++ file & function statics.
		if (IsMdPrivateScope(dwMemberAccess)) {
			if (pCurrentClass == NULL)
				return FALSE;
			_ASSERTE(pTargetClass);
	        
			return (pCurrentClass->GetModule() == pTargetClass->GetModule());
		}
