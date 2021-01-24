    public IEnumerable<Employee> GetEmployees()
    {
        string connectionString = "CONNECTION STRING";
        string commandText = "COMMAND TEXT";
        DataTable table = new DataTable();
        using (var adapter = new MySqlDataAdapter(commandText , connectionString))
            adapter.Fill(table);
        return table.AsEnumerable().Select(x => new Employee()
        {
            FirstName = x.Field<string>("FirstName"),
            LastName = x.Field<string>("LastName")
        });
    }
