    using (var scope = new TransactionScope(TransactionScopeOption.Required, 
           new TransactionOptions { IsolationLevel = IsolationLevel.RepetableRead} ))
    {
        // Grab data
        // Process changes
        context.SaveChanges();
        scope.Complete();
    }
