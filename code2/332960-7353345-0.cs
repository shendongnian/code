    foreach (ObjectContext ctx in Storage.GetAllObjectContexts())
    {
        if (ctx.Connection.State == System.Data.ConnectionState.Open)
            ctx.Connection.Close();
    }
