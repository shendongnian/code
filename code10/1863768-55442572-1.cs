     string StrQuery;
            try
            {
                using (SqlConnection conn = new SqlConnection(stringcon))
                {
                        for (int i = 0; i < bunifuCustomDataGrid2.Rows.Count; i++)
                        {
                            SqlCommand comm = new SqlCommand();
                            comm.Connection = conn;
                            StrQuery = @"INSERT INTO concediati(nume,prenume,idcar,idrent,idclient) VALUES (@name,@lastname,@car,@rent,@client)";
                            comm.Parameters.AddWithValue("@name", Convert.ToString(bunifuCustomDataGrid2.Rows[i].Cells["firstname"].ToString()));
                            comm.Parameters.AddWithValue("@lastname", Convert.ToString(bunifuCustomDataGrid2.Rows[i].Cells["lastname"].ToString()));
                            comm.Parameters.AddWithValue("@car", Convert.ToInt32(bunifuCustomDataGrid2.Rows[i].Cells["CARS"].ToString()));
                            comm.Parameters.AddWithValue("@rent", Convert.ToInt32(bunifuCustomDataGrid2.Rows[i].Cells["RENT"].ToString()));
                            comm.Parameters.AddWithValue("@client", Convert.ToInt32(bunifuCustomDataGrid2.Rows[i].Cells["CLIENT"].ToString()));
                            comm.CommandText = StrQuery;
                            conn.Open();
                            comm.ExecuteNonQuery();
                            conn.Close();
                            
                        }
                    }
            }
            catch (Exception ex)
            {
                throw;
            }
