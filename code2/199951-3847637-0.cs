    ItemView view = new ItemView(10, 0, OffsetBasePoint.Beginning);
    view.OrderBy.Add(ItemSchema.DateTimeReceived, SortDirection.Descending);
    view.PropertySet = new PropertySet(
        BasePropertySet.IdOnly,
        ItemSchema.Subject,
        ItemSchema.DateTimeReceived);
    
    // save the folder where we will make searching to do this one time
    Folder myInbox = Folder.Bind(service, WellKnownFolderName.Inbox);
    
    FindItemsResults<Item> findResults;
    
    do
    {
        findResults = myInbox.FindItems(
            new SearchFilter.ContainsSubstring(ItemSchema.Subject,
                    Properties.Settings.Default.EmailSubject)),
            view);
    
        foreach (Item item in findResults)
        {
            // Do something with the item.
            Console.WriteLine();
            if (item is EmailMessage)
            {
                EmailMessage em = item as EmailMessage;
                Console.WriteLine("Subject: \"{0}\"", em.Subject);
            }
            else if (item is MeetingRequest)
            {
                MeetingRequest mr = item as MeetingRequest;
                Console.WriteLine("Subject: \"{0}\"", mr.Subject);
            }
            else
            {
                // we can handle other item types
            }
        }
    
        //any more batches?
        if (findResults.NextPageOffset.HasValue)
        {
            view.Offset = findResults.NextPageOffset.Value;
        }
    }
    while (findResults.MoreAvailable);
