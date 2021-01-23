    public IQueryable<Client> GetTopLevelData(Guid agentGuid, int year)
    {
        var clients =
            from client in ObjectContext.Clients
            join cbc in ObjectContext.Client_Bucket_Client on client.Client_GUID equals cbc.Client_GUID
            join acb in ObjectContext.Agent_Client_Bucket on cbc.Client_Bucket_GUID equals acb.Client_Bucket_GUID
            where acb.Agent_GUID == agentGuid
            select client;
        var clientInfos =
            from c in clients
            select new
            {
                Client = c,
                TransactionInfos = ObjectContext.Transactions
                    .Where(t => t.Client_GUID == c.Client_GUID && t.Year == year)
                    .Select(t => new
                    {
                        Transaction = t,
                        ToAttach = ObjectContext.Forms.Where(f => f.Transaction_GUID == t.Transaction_GUID && f.Year == year) //.OrderByDescending(fo => fo.Create_Date)
                    })
            };
        // Looping over this query will hit the database *once*
        foreach (var info in clientInfos)
        {
            foreach (var transactionInfo in info.TransactionInfos)
                transactionInfo.Transaction.Forms.Attach(transactionInfo.ToAttach);
            info.Client.Transactions.Attach(info.TransactionInfos.Select(t => t.Transaction));
        }
        // Return a queryable object; constructing a new query from this will hit the database one more time
        return clients;
    }
