    ItemView view = new ItemView(100);
    
    Guid MyPropertySetId = new Guid("{C11FF724-AA03-4555-9952-8FA248A11C3E}");
    
    view.PropertySet = new PropertySet(BasePropertySet.IdOnly, ItemSchema.Subject, extendedPropertyDefinition);
    
    FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, view);
