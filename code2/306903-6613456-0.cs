using(var dt = new DataTable()) {
    dt.Columns.Add("Name");
    dt.Columns.Add("Description");
    dt.Columns.Add("InvariantName");
    dt.Columns.Add("AssemblyQualifiedName");
    dt.Rows.Add("Mysql something", 
        "mysql more", 
        "mysqlClient",
        "MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data, Version=6.4.3.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d");
    var f = DbProviderFactories.GetFactory(dt.Rows[0]);
    using(var conn = f.CreateConnection()) {
        conn.ConnectionString = "your string here";
        conn.Open();
        // and do your work here.
        Console.WriteLine(conn);
    }
}
