    using (var command = context.Database.GetDbConnection().CreateCommand())
    {
        command.CommandText = "SELECT * From Make";
        context.Database.OpenConnection();
        using (var reader = command.ExecuteReader())
        {
            // Do something with result
            reader.Read(); // Read first row
            var firstColumnObject = reader.GetValue(0);
            var secondColumnObject = reader.GetValue(1);
    
            reader.Read(); // Read second row
            firstColumnObject = reader.GetValue(0);
            secondColumnObject = reader.GetValue(1);
        }
    }
