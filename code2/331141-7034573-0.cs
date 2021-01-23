    var db = Database.Open();
    var tx = db.BeginTransaction(); // Internal IDbConnection opened by this call
    try
    {
        order = tx.Orders.Insert(order); // Returned record will have new IDENTITY value
        foreach (var item in items)
        {
            item.OrderId = order.Id;
            tx.Items.Insert(item);
        }
        tx.Commit(); // Internal IDbConnection closed by this call...
    }
    catch
    {
        tx.Rollback(); // ...or this call :)
    }
