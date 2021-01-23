    static bool IsMember(DirectoryEntry group, DirectoryEntry user)
    {
        group.RefreshCache(new string[] { "objectSid" });
        SecurityIdentifier groupSID =
            new SecurityIdentifier((byte[])group.Properties["objectSid"].Value, 0);
        
        IdentityReferenceCollection refCol;
        user.RefreshCache(new string[] { "tokenGroups" });
        IdentityReferenceCollection irc = new IdentityReferenceCollection();
        foreach (byte[] sidBytes in user.Properties["tokenGroups"])
        {
            irc.Add(new SecurityIdentifier(sidBytes, 0));
        }
        refCol = irc.Translate(typeof(NTAccount));
        PropertyValueCollection props = user.Properties["tokenGroups"];
        foreach (byte[] sidBytes in props)
        {
            SecurityIdentifier currentUserSID = new SecurityIdentifier(sidBytes, 0);
            if (currentUserSID.Equals(groupSID))
            {
                return true;
            }
        }
        return false;
    }
