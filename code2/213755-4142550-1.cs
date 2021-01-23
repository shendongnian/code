    private buttonUpdate_Click((object sender, EventArgs e)
    {
        // You should use parameterized query. But for now, this example would do.
        string sql = "UPDATE TABLE SET NAME = " + dc.Name + " WHERE ID = '" + dc.ID +"'";
        bool flag = UpdateRecord(sql);
    
        if(flag)
            MessageBox.Show("Record updated!");
        else
            MessageBox.Show("Update failed!");
    }
    
    private bool UpdateRecord(sql)
    {
        bool flag = false; // Presume update failed.
    
        SqlConnection conn = new SqlConnection(yourConnString);
        try
        {
             conn.Open();
             SqlCommand cmd = new SqlCommand(sql);
             flag = (bool)cmd.ExecuteNonQuery();
        }
        catch
        {
              // Do some error logging.
        }
        finally
        {
             // Finally block always execute, so close here your connection and return here the flag value.
             conn.Close();
             return flag; // Return default value of flag, (false)
        }
        return flag; 
    }
