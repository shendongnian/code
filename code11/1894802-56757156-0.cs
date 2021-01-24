    using (SqlConnection conn = new SqlConnection("ConnectionString"))
            {
                SqlCommand sqlComm = new SqlCommand("Get_lineFromSchema", conn);
                sqlComm.Parameters.AddWithValue("@Category", cid);
                
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;
                DataTable result = new DataTable();
                da.Fill(result);
                CategoryCombo.DataSource = result;
            }
