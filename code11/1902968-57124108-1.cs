// Assumes that command is a NpgsqlCommand object and that  
// connectionString connects to master.  
command.Text = "\connect DatabaseName";  
using (NpgsqlConnection connection = new NpgsqlConnection(  
  connectionString))  
  {  
    connection.Open();  
    command.ExecuteNonQuery();  
  }  
