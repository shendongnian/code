    using (var context = new PrincipalContext(ContextType.Domain))
    {
        var group = GroupPrincipal.FindByIdentity(context, "GroupName");
        var dirEntry = (DirectoryEntry)group.GetUnderlyingObject();
    
        dirEntry.Rename("CN" + "NewGroupName");
        dirEntry.CommitChanges();
    }
