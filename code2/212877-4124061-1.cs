        string _connStr = @"Data Source=SERVER1\SQLEXPRESS;Initial Catalog=Alkawthar;Integrated Security=True;Pooling=False";
        string _query = "SELECT * FROM Workers";
        DataSet _ds = new DataSet();
        try
        {
            using (SqlConnection _conn = new SqlConnection(_connStr))
            {
                SqlDataAdapter _da = new SqlDataAdapter(_query, _conn);
                _conn.Open();
                _da.Fill(_ds);
            }
            
            // insert null dataset or invalid return logic (too many tables, too few columns/rows, etc here.
            if (_ds.Tables.Count == 1)
            { //There is a table, assign the name to it.
                _ds.Tables[0].TableName = "tblWorkers";
            }
            //Then work with your tblWorkers
        }
        catch (Exception ex)
        {
            Console.Write("An error occurred: {0}", ex.Message);
        }
