    string connString = "Server=.\\SQLEXPRESS;database=YourDatabase;Integrated Security=True";
    string query = "INSERT INTO dbo.Student(navn, etternavn) " + 
       "VALUES(@navn, @etternvan)";
    using(SqlConnection conn = new SqlConnection(connString))
    using(SqlCommand myCmd = new SqlCommand(query, conn))
    {
       // set up parameters
       myCmd.Parameters.Add("@navn", SqlDbType.VarChar, 100).Value = NavnTextBox.Text.Trim();
       myCmd.Parameters.Add("@etternavn", SqlDbType.VarChar, 100).Value = EtterNavnTextBox.Text.Trim();
 
       try
       {
           conn.Open();
           myCmd.ExecuteNonQuery();
           conn.Close();
       }
       catch (Exception ex)
       {
          Console.WriteLine("Error: " + ex);
       }
    }
