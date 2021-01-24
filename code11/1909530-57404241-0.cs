    var uidsWithMailId = folder.Search (SearchQuery.BodyContains (mailid));
    var items = folder.Fetch (uidsWithMailId, MessageSummaryItems.UniqueId | MessageSummaryItems.Envelope);
    var tenMinutesAgo = DateTime.Now.AddMinutes (-10);
    var matches = new UniqueIdSet ();
    foreach (var item in items) {
        // check if the message was sent within the last 10 minutes
        if (item.Envelope.Date >= tenMinutesAgo) {
            // add the message UID to our list of matches
            matches.Add (item.UniqueId);
        }
    }
