    string conString = "data source=.;initial catalog=myDB;integrated security=True";
        
    using(var tableDependency = new SqlTableDependency<Customers>(conString))
    {
        tableDependency.OnChanged += TableDependency_Changed;
        tableDependency.Start();
    
        Console.WriteLine("Waiting for receiving notifications...");
        Console.WriteLine("Press a key to stop");
        Console.ReadKey();
    }
    ...
    ...
    void TableDependency_Changed(object sender, RecordChangedEventArgs<Customers> e)
    {
        if (e.ChangeType != ChangeType.None)
        {
            var changedEntity = e.Entity;
            Console.WriteLine("DML operation: " + e.ChangeType);
            Console.WriteLine("ID: " + changedEntity.Id);
            Console.WriteLine("Name: " + changedEntity.Name);
            Console.WriteLine("Surname: " + changedEntity.Surname);
        }
    }
