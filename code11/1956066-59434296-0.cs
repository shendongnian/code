csharp
    var transactions = userCollection.AsQueryable()
                         .Where(u => u.LoginId.Contains("a"))
                         .Join(transactionCollection.AsQueryable(),
                               u => u.Id,
                               t => t.UserId,
                               (u, t) => t)
                         .ToList();
here's a full test program:
