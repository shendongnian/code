    string applicationname = "";
    using(var reader = command.ExecuteReader()) 
     {
        reader.Read();
        applicationname = reader.GetString(reader.GetOrdinal("applicationname"));
     }
