    //...
    var predicate = PredicateBuilder.True<TransactionLine>()
                   .And(x => x.Transaction.CreditAccount.UserAccount == userAccount && x.Transaction.Deleted == null);
    if (request.FromDate.HasValue)
        predicate = predicate.And(x => x.Transaction.Date >= request.FromDate);
    if (request.ToDate.HasValue)
        predicate = predicate.And(x => x.Transaction.Date <= request.ToDate);
    if (request.AccountId.HasValue)
        predicate = predicate.And(x => x.Transaction.CreditAccount.ExternalId == request.AccountId || x.Transaction.DebitAccount.ExternalId == request.AccountId);
    if (request.HistoricDaysFromNow.HasValue)
        predicate = predicate.And(x => x.Transaction.Date >= DateTime.UtcNow.AddDays(request.HistoricDaysFromNow.Value * -1));
    //...
