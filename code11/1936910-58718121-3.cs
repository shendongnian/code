    if (e.ChangeType != ChangeType.None)
    {
        var changedEntity = e.Entity;
        var id = GetPrimaryKey(changedEntity)
        _ctx.Transactions.Find(id);
    }
