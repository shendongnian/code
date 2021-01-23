    string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
    builder.ApplicationName = "linqtosql";
    
    using (var context = new DataContext(builder.ConnectionString)) {
        var list = context.Customers.ToList();
    }
