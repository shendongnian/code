            using (DbConnection con = new SqlConnection())
            {
                con.ConnectionString = ...;
                con.Open();
                DataTable tabeWithSchemaInfo = con.GetSchema("AllColumns");
