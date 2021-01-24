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
                cmd.Parameters.Add("@RegionDescription", SqlDbType.VarChar, 40).Value = item.Text.Trim();
                cmd.Parameters.Add("@Fname", SqlDbType.VarChar, 40).Value = item.SubItems[1].Text.Trim();
                cmd.Parameters.Add("@Lname", SqlDbType.VarChar, 40).Value = item.SubItems[2].Text.Trim(); 
                cmd.ExecuteNonQuery();
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
