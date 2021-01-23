    var cde = new CountdownEvent(items.Count);
    foreach (var item in items)
    {
        ...
        client.DownloadFileCompleted += (a, b) =>
        {
            lock (message)
            {
                message.Attachments.Add(new Attachment(fileName));
                cde.AddCount();
            }
        };
        ...
    }
    // If we've downloaded all the items,
    // send the message with the items attached to it
    cde.Wait();
    lock (message)
    {
        SendMessage(message);
    }
    
