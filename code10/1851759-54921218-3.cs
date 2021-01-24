     using(SqliteConnection con = new SqliteConnection(cs))
            {            
                con.Open();
    
                SqliteCommand cmd = new SqliteCommand(con);   
                cmd.CommandText = "SELECT Data FROM Images WHERE Id=1";
                byte[] data = (byte[]) cmd.ExecuteScalar();
    
                try
                {               
                    if (data != null)
                    { 
                        File.WriteAllBytes("woman2.jpg", data);
                        myimage = data
                    } else 
                    {
                        Console.WriteLine("Binary data not read");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }            
    
                con.Close();
            }
