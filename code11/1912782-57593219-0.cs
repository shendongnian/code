    IList<T> allEmailList = new List<T>();
    FindItemsResults<Item> emailItemList = service.FindItems(WellKnownFolderName.Inbox, sf, view);
    foreach (var emailItem in emailItemList.Items.OfType<T>())
    {
        Console.WriteLine(inboxCount + ". " + emailItem.Subject);
        inboxCount++;
        //add this email to an allEmailList
		allEmailList.Add(emailItem);
    }
