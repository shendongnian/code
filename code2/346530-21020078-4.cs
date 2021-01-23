    using (var context = new PrincipalContext(ContextType.Domain))
    {
        var group = GroupPrincipal.FindByIdentity(context, groupName);
        group.SamAccountName = newGroupName;
        group.DisplayName = newGroupName;
        group.Save();
        DirectoryEntry dirEntry = (DirectoryEntry)group.GetUnderlyingObject();    
        dirEntry.Rename("CN=" + newGroupName);
        dirEntry.CommitChanges();
    }
