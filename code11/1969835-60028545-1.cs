      string sql = "SELECT* From Employee where EmployeeId = @EmployeeId";
            try
            {
                using (SqlConnection connection = new SqlConnection(cnStr))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("EmployeeId", TxtId.Text);
                        command.ExecuteNonQuery();
                        Form1_Load(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
