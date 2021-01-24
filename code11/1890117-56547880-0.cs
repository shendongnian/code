       internal string GetSexDescription(string sex, int id_merchant)
        {
            string newSex = "";
            var builder = new ConnectionStringHelper();
            var connString = builder.getCasinoDBString(id_merchant);
            DataSet ds = new DataSet();
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string sql = "SELECT Description FROM person_gender_lookup WHERE ID = @Sex";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    try
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        adapter.SelectCommand = cmd;
                        cmd.Parameters.Add("@Sex", SqlDbType.VarChar).Value = sex;
                        adapter.Fill(ds);
                        newSex = cmd.ExecuteScalar().ToString();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return newSex;
                }
            }
            
        }
