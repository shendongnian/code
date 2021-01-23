    foreach(string fp in filePaths)
    {
       InsertIntoDb(fp);
    }
    //Method
    public void InsertIntoDb(string insert)
    {
       SqlConnection con = //Setup DB connection
       SqlCommand command = new SqlCommand();
       command.Connection = con;
       command.CommandText = "Insert @insert into Table";
       command.Parameters.AddWithValue("@insert", insert);
       command.ExecuteNonQuery();
    }
