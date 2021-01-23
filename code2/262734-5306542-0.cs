    IQueryable<MyObject> concatquery;
    int[] allMessageTypeIDs = new int[] { 0, 1, 2 };
    for (int mt = 0; mt < allMessageTypeIDs.Length; mt++)
    {
        var myItem = allMessageTypeIDs[mt]; // <-- HERE!
        if (mt == 0)
        {
            concatquery = (from pm in db.ParsedMessages
                           join pml in db.ParsedMessageLinks on pm.ParsedMessageID equals pml.ParsedMessageID
                           where pml.AnotherID == 0 && pm.MessageTypeID == myItem
                           orderby pm.ParsedMessageID descending
                           select new MyObject
                           {
                               NumberOfOccurences = pml.Occurrences,
                               ParsedMessage = pm
                           }).Take(100);
        }
        else
        {
            concatquery = concatquery.Concat(from pm in db.ParsedMessages
                                            join pml in db.ParsedMessageLinks on pm.ParsedMessageID equals pml.ParsedMessageID
                                            where pml.AnotherID == 0 && pm.MessageTypeID == myItem
                                            orderby pm.ParsedMessageID descending
                                            select new MyObject
                                            {
                                                NumberOfOccurences = pml.Occurrences,
                                                ParsedMessage = pm
                                            }).Take(100);
        }
    }
    var results = concatquery.ToArray();
