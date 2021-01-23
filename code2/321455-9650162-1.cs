    foreach (FileSystemAccessRule ace in acl)
    {
        if (groupsToRemove.Contains(ace.IdentityReference.Value))
        {
            dirSec.RemoveAccessRuleSpecific(ace);        
        }
    }
    dirInfo.SetAccessControl(dirSec);
