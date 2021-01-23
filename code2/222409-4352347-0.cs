    using (var connection = new SqlConnection("Persist Security Info=False;Integrated Security=true;server=(local);Initial Catalog=test;"))
    {
        try
        {
             connection.Open();
        }
        catch (SqlException sqlException)
        {
            MessageBox.Show(sqlException.Message, "Unable to connect");
        }
    }
