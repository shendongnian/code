    DirectorySearcher ds = new DirectorySearcher();
    ds.Filter = String.Format("(&(objectClass=user)(sAMAccountName={0}))", username);
    SearchResult sr = ds.FindOne();
    
    DirectoryEntry user = sr.GetDirectoryEntry();
    user.RefreshCache(new string[] { "tokenGroups" });
    
    for (int i = 0; i < user.Properties["tokenGroups"].Count; i++) {
        SecurityIdentifier sid = new SecurityIdentifier((byte[]) user.Properties["tokenGroups"][i], 0);
        NTAccount nt = (NTAccount)sid.Translate(typeof(NTAccount));
        //do something with the SID or name (nt.Value)
    }
            
