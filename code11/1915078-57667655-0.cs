    connection.Open();
    NpgsqlCommand cmd = new NpgsqlCommand();
    NpgsqlDataReader dr=null;
    cmd.Connection = connection;
    cmd.CommandText = ("SELECT f_name FROM student_folio WHERE id = 1");
    cmd.CommandType = CommandType.Text;
    dr=cmd.ExecuteReader();
    while(dr.HasRows)
    {
       while(dr.Read())
       {
           txtFname.Text = da["f_name"].ToString();
       }
    }
    
    
    connection.Close();
