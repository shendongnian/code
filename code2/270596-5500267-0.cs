    try
    {
       using(SQLConnection c = new SQLConnection(connectionString))
       {
           c.Open();
           string w = "insert into checkmultiuser(username) values (@username)";
       }  
       using(SQLCommand cmd = new SQLCommand(w,c))
       {
            cmd.Parameters.Add("@username", SqlDbType.VarChar);    cmd.Parameters["@username"].Value =    textBox1.Text;    //cmd.ExecuteNonQuery();    cmd.ExecuteReader();
       }
       c.Close();
    }
    catch(Exception e)
    {
         Console.WriteLine(e.Message);
    }
