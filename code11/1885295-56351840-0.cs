    try
    {
       using (SqlConnection conn = new SqlConnection("connection"))
       {
          conn.Open();
        }
    }
    catch(Exception ex)
    {
       MessageBox.Show(ex.Message, "Invalid Connection String");
    }
