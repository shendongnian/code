    string connectionString = "Data Source=.;Initial Catalog=Northwind;Integrated Security=True";
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();
                    
        DataTable dtAllForeignKeys = conn.GetSchema("ForeignKeys");
    
        string[] restrictionValues = { "Northwind", "dbo", "Orders" };
        DataTable dtForeignKeysForJustTheOrderTable = conn.GetSchema("ForeignKeys", restrictionValues);
        conn.Close();
    }
