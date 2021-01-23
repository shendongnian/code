    using (System.Data.SqlClient.SqlConnection c = new System.Data.SqlClient.SqlConnection("Data Source=..."))
    {
        using (System.Data.SqlClient.SqlDataAdapter a = new System.Data.SqlClient.SqlDataAdapter("select * from atable;", c))
        {
            using (System.Data.SqlClient.SqlCommandBuilder b = new System.Data.SqlClient.SqlCommandBuilder(a))
            {
                using (DataTable t = new DataTable("atable"))
                {
                    a.FillSchema(t, SchemaType.Source);
                    t.Rows.Add(1, "foo");
                    t.Rows.Add(2, "bar");
                    a.Update(t);
                }
            }
        }
    }
