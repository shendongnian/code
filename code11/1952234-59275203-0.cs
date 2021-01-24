	var sid = new SecurityIdentifier( WellKnownSidType.WorldSid, null );
	var ace = new AccessRule<MemoryMappedFileRights>( sid,
								MemoryMappedFileRights.FullControl, AccessControlType.Allow );
	var acl = new MemoryMappedFileSecurity();
	acl.AddAccessRule( ace );
