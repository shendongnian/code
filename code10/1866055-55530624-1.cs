            string query = @"INSERT INTO MED (id,idtran,qty,user)
                                        Values(@id,@idtran,@qty,@user)";
            using (SqlConnection xcon = new SqlConnection(@"Server=MEAND;Database=SHC;Integrated Security=SSPI;"))
            {
				try
				{
					xcon.Open();
					foreach (DataGridViewRow row in dataGridView2.Rows)
					{
						using (SqlCommand xcom = new SqlCommand(query, xcon))
						{
							xcom.CommandType = CommandType.Text;
							xcom.Parameters.AddWithValue("@id", row.Cells["id"].Value);
							xcom.Parameters.AddWithValue("@idtran", row.Cells["idtran"].Value);
							xcom.Parameters.AddWithValue("@qty", row.Cells["qty"].Value);
							xcom.Parameters.AddWithValue("@user", row.Cells["user"].Value);
							xcom.ExecuteNonQuery();xcom.Dispose();
						}
					}					
				}
				catch
				{
					//do what you need
				}
				finally
				{
					xcon.Close();
				}
			}
