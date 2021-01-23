    public IQueryable<Client> GetTopLevelData(Guid agentGuid, int year)
    {
        var clients = from client in ObjectContext.Clients
                      join cbc in ObjectContext.Client_Bucket_Client on client.Client_GUID equals cbc.Client_GUID
                      join acb in ObjectContext.Agent_Client_Bucket on cbc.Client_Bucket_GUID equals acb.Client_Bucket_GUID
                      where acb.Agent_GUID == agentGuid
                      orderby client.Last_Change_Date descending, client.File_Under
                      select client;
        var clientTransactions = clients
                    .Join(ObjectContext.Transactions, c => c.Client_GUID, t => t.Client_GUID,
                                (c, t) => new { Transaction = t });
        var clientForms = clientTransactions
                    .Join(ObjectContext.Forms, t => t.Transaction.Transaction_GUID, f => f.Transaction_GUID,
                                (t, f) => new { Form = f });
        foreach (var client in clients)
        {
            var clientTrans = from trans in clientTransactions where trans.Transaction.Client_GUID == client.Client_GUID && trans.Transaction.Year == year select trans;
            foreach (var trans in clientTrans)
            {
                client.Transactions.Attach(trans.Transaction);
                var transForms = from forms in clientForms where forms.Form.Transaction_GUID == trans.Transaction.Transaction_GUID && forms.Form.Year == year select forms;
                foreach (var form in transForms)
                {
                    trans.Transaction.Forms.Attach(form.Form);                                                             
                }
            }
        }
        return clients;
    }
