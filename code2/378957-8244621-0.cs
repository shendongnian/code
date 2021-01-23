    static DataTable GetProviderFactoryClasses()
    {
        // Retrieve the installed providers and factories.
        DataTable table = DbProviderFactories.GetFactoryClasses();
    
        // Display each row and column value.
        foreach (DataRow row in table.Rows)
        {
            foreach (DataColumn column in table.Columns)
            {
                Console.WriteLine(row[column]);
            }
        }
        return table;
    }
