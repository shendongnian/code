    using(var tableDependency = new SqlTableDependency<Transaction>(conString))
    {
        tableDependency.OnChanged += TableDependency_Changed;
        tableDependency.Start();
    }
    
    void TableDependency_Changed(object sender, RecordChangedEventArgs<Transaction> e)
    {
        if (e.ChangeType != ChangeType.None)
        {
            var changedEntity = e.Entity;
            //You'll need to change this logic to send only to the people you want to 
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            hubContext.Clients.All.notifyClients(entity);
        }
    }
