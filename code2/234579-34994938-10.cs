    private void ExplicitlyLoadMembers(dynamic item)
    {
        foreach (var property in ((Type)item.GetType()).GetProperties())
        {
            DbEntityEntry dbEntityEntry = Entry(item);
            var dbMemberEntry = dbEntityEntry.Member(property.Name);
    
            // If we're dealing with a Reference or Collection entity, explicitly load the properties if necessary.
            if (dbMemberEntry is DbReferenceEntry)
            {
                if (!dbEntityEntry.Reference(property.Name).IsLoaded)
                {
                    dbEntityEntry.Reference(property.Name).Load();
                }
            }
            else if (dbMemberEntry is DbCollectionEntry)
            {
                if (!dbEntityEntry.Collection(property.Name).IsLoaded)
                {
                    dbEntityEntry.Collection(property.Name).Load();
                }
            }
        }
    }
