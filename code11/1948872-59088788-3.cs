    var queryJoin = (from inn in db.Input.Take(1)
                             join y in db.InputY on inn.YAction equals y.YAction
                             orderby inn.Id descending
                             select new StageTwo
                             {
                                 Id = inn.Id,
                                 Party = inn.XParty,
                                 Currency = inn.Curr,
                                 DrCr = y.DrAccount1,
                                 Account = y.YAction,
                                 Amount = inn.Amount
                             });
    return queryJoin;
