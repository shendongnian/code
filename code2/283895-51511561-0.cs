    private void UpdateAllRecord()
        {
            StringBuilder query = new StringBuilder();
            for (int i = 0; i < GridViewName.Rows.Count; i++)
            {
                GridViewRow row = GridViewName.Rows[i];
                using (SqlConnection con = new SqlConnection(connStr)) //use your connection string
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("update YourTable set  ColumnName=@ColumnName where Id= " + row.Cells[0].Controls.OfType<TextBox>().FirstOrDefault().Text + "  ", con);
                    cmd1.Parameters.AddWithValue("@ColumnName", row.Cells[5].Controls.OfType<TextBox>().FirstOrDefault().Text);                
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
