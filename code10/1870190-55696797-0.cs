    using (var transaction = connection.BeginTransaction())
    using (var command = connection.CreateCommand())
    {
        command.CommandText =
            "INSERT INTO contact(name, email) " +
            "VALUES($name, $email);";
    
        var nameParameter = command.CreateParameter();
        nameParameter.ParameterName = "$name";
        command.Parameters.Add(nameParameter);
    
        var emailParameter = command.CreateParameter();
        emailParameter.ParameterName = "$email";
        command.Parameters.Add(emailParameter);
    
        foreach (var contact in contacts)
        {
            nameParameter.Value = contact.Name ?? DBNull.Value;
            emailParameter.Value = contact.Email ?? DBNull.Value;
            command.ExecuteNonQuery();
        }
    
        transaction.Commit();
    }
