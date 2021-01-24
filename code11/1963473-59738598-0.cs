        try
        {
            DirectoryEntry ent = new DirectoryEntry(bindString);
            ent.Properties["member"].Add(newMember);
            ent.CommitChanges();
        }
            
            
