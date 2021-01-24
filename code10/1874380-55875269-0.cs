    public ICollection<OrderDocumentModel> SearchOrders(string accountNumber, TimeFrame timeFrame, string search)
    {
        var db = _mongoClient.GetDatabase("my-database");
        var regex = new Regex(search ?? string.Empty);
        var dbCollection = db.GetCollection<OrderDocumentModel>("my-collection");
        var results = dbCollection.Find(x => x.AccountNumber == accountNumber
                         && x.ReceivedDateTime >= timeFrame.FromDateTime
                         && x.ReceivedDateTime <= timeFrame.ToDateTime
                         && x.SearchTerms.Any(s => regex.IsMatch(s))
                         ).ToList();
        return results.ToList();
    }
