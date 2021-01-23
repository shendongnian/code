    using (TransactionScope tran = new TransactionScope())
    {
        if (Transaction.Current.TransactionInformation.DistributedIdentifier == Guid.Empty)
        {
            // ambient transaction is not escalated; exclude this operation from the ambient transaction
            using (TransactionScope tran2 = new TransactionScope(TransactionScopeOption.Suppress))
            {
                // do some stuff
            }
        }
        else
        {
            // ambient transaction is escalated
            // do some other stuff
        }
    }
