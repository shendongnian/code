    private void button1_Click(object sender, EventArgs e, string[] value)
    {
          try
          {
               using(SQLConnection c = new SQLConnection(connectionString))  
               using(SQLCommand cmd = new SQLCommand(c))
               {
                   c.Open();
                   
                   string w = "insert into checkmultiuser(username) values (@username)";
        
                   cmd.CommandText = w;
                   cmd.Parameters.Add("@username", SqlDbType.VarChar);    
    
                   for(int i = 0; i < value.Length; i++)
                   {
                       cmd.Parameters["@username"].Value = value[i];    
                       cmd.ExecuteReader();
                   }
                   c.Close();
               }
            }
            catch(Exception e)
            {
                 Console.WriteLine(e.Message);
            }
    }
