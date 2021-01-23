    try
    {
        string Releasedate = Calendar1.SelectedDate.Date.ToString();
        SqlCommand cmd = new SqlCommand("INSERT INTO mydb (date) VALUES ('"+Releasedate+"')", sqlcon);
        sqlcon.Open();
        cmd.ExecuteNonQuery();
    }
    catch (Exception ex)
    {               
        Response.Write(ex.Message);
    }
    finally
    {
        sqlcon.Close();
    }
