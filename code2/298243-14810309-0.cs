    private static bool IsMember(DirectoryEntry group, DirectoryEntry user)
    {
    	SecurityIdentifier userSId = new SecurityIdentifier((byte[])user.Properties["objectSid"].Value, 0);
    	foreach (object member in (IEnumerable)group.Invoke("Members"))
            {
    		using (var memberEntry = new DirectoryEntry(member))
                    {
                        var groupSId = new SecurityIdentifier((byte[])memberEntry.Properties["objectSid"].Value, 0);
                        if (userSId.Equals(groupSId))
                        {
                            return true;
                        }
                    }
    	}
    
    	return true;
    }
