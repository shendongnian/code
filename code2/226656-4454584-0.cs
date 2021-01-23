               public DirectoryEntry FindDomain(DirectoryEntry memberEntry) 
               {
                           
                    if(memberEntry.SchemaClassName.ToLower().Contains("domain") 
                    {
                           return memberEntry;
                    }   
                    if(memberEntry.Parent !=null) 
                    {
                             return FindDomain(memberEntry.Parent);
                    }
                    return null;
               }
