    switch (outlookEvent.EventType)
    {
        case EventType.Moved:
            var folder = Folder.Bind(subscription.Value.EwsInstance, WellKnownFolderName.DeletedItems);
                                if (Equals(outlookEvent.ParentFolderId.UniqueId, folder.Id.UniqueId))
                                {
                                    Console.WriteLine("Moved to DeletedItems " + outlookEvent.ItemId);
                                }
