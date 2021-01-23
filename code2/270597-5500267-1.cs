      try
      {
           using(SQLConnection c = new SQLConnection(connectionString))  
           using(SQLCommand cmd = new SQLCommand(c))
           {
               c.Open();
               
               string w = "insert into checkmultiuser(username) values (@username)";
    
               cmd.CommandText = w;
               cmd.Parameters.Add("@username", SqlDbType.VarChar);    
               cmd.Parameters["@username"].Value = textBox1.Text;    
               cmd.ExecuteReader();
               c.Close();
           }
        }
        catch(Exception e)
        {
             Console.WriteLine(e.Message);
        }
