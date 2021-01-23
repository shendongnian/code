         try
         {
           using (var con = new SqlConnection(@"Data Source=..."))
           {
             var cad = "INSERT INTO table VALUES (@r1,@r2,@r3)";
             
             using (var insertCommand = new SqlCommand(cad, con))
             {
               insertCommand.Parameters.AddWithValue("@r1", atxt);
               insertCommand.Parameters.AddWithValue("@r2", btxt);
               insertCommand.Parameters.AddWithValue("@r3", ctxt);
               con.Open();
               insertCommand.ExecuteNonQuery();
             }
           }
         }
         catch (Exception ex)
         {
           MessageBox.Show("Error: " + ex.Message, "UsingTest", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
