    // Set the offset for the paged search.
    int offset = 0;
    // Set the page size. (You may want to change this value)
    const int pageSize = 3;
    // Set the flag that indicates whether to continue iterating through additional pages.
    bool MoreItems = true;
    LogFile.AppendLog(folder.DisplayName + " folder found in Inbox.");
    if (folder.DisplayName == folderName)
    {
        // Continue paging while there are more items to page.
        while (MoreItems)
        {
            LogFile.AppendLog(folder.DisplayName + " matches " + folderName);
            // Set the ItemView with the page size and offset.
            ItemView view = new ItemView(emailBatch, pageSize, offset, OffsetBasePoint.Beginning);
            LogFile.AppendLog("Checking for unread emails in folder " + folder.DisplayName);
            emailItemList = service.FindItems(folder.Id, sf, view);
            foreach (var emailItem in emailItemList.Items)
            {
                LogFile.AppendLog("Getting unread emails in folder " + folder.DisplayName);
                EmailMessage email = EmailMessage.Bind(service, emailItem.Id);
                retrievedEmailList.Add((EmailMessage)email);
            }
            // Set the flag to discontinue paging.
            if (!emailItemList.MoreAvailable)
                MoreItems = false;
            // Update the offset if there are more items to page.
            if (MoreItems)
                offset += pageSize;
        }
    }
