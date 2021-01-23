    var connectionString = new SqlConnectionStringBuilder
    {
        DataSource = @"C:\Temp\Northwind.mdf"
    };
    var commandText = "select * from Customers";
    using (var rows = new SqlCommandHelper(connectionString.ToString(), System.Data.CommandType.Text, commandText))
    {
        foreach (dynamic row in rows)
        {
            try
            {
                Console.WriteLine(row.Fax ?? "Emtpy");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid column name");
            }
        }
    }
