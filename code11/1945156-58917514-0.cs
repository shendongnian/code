    DateTime dt = DateTime.Parse(Convert.ToString(CurrentItem[SharePointColumnInternal[j]]));
    dt = dt.ToLocalTime();
    
    using (var connection = new OracleConnection("YourConnectionString"))
    using (var command = new OracleCommand("UPDATE YourTable SET YourDateTimeColumn = :dt Where ...", connection))
    {
        command.Parameters.Add("dt", dt);
        command.ExecuteNonQuery();
    }
