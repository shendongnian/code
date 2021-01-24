    try
    {
        string connectionString = ConfigurationSettings.AppSettings["conn"];
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd;
            conn.Open();
            string cmdString = @"INSERT INTO Region (RegionDescription, Fname, Lname) 
                                 VALUES (@RegionDescription, @Fname, @Lname)";
                    
            foreach (ListViewItem item in lvregion.Items)
            {
                cmd = new SqlCommand(cmdString, conn);
                cmd.Parameters.AddWithValue("@RegionDescription", item.Text.Trim());
                cmd.Parameters.AddWithValue("@Fname", item.SubItems[1].Text.Trim());
                cmd.Parameters.AddWithValue("@Lname", item.SubItems[2].Text.Trim()); 
                cmd.ExecuteNonQuery();
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
