       public void count_accno() {
         //TODO: instead of opening existing connection, create a new one  
         conn.Open();
    
         try { 
           string str = 
             @"SELECT MAX([Category ID]) -- wild guess: escapement
                 FROM Category"; 
    
           //DONE: wrap IDisposable into using
           using (SqlCommand cmd = new SqlCommand(str, conn)) {
             //TODO: Have a look at ExecuteScalar
             using (SqlDataReader dr = cmd.ExecuteReader()) {
               //DONE: we want 1st record only (if instead of while)
               if (dr.Read()) {
                 // Convert is safier oprion when converting object
                 textBox1.Text = (Convert.ToInt32(dr[0]) + 1).ToString();
               }
             }
           }
         }
         finally {
           // finally: rain or shine close the connection
           conn.Close();
         }
       }
