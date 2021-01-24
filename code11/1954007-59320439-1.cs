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
               //DONE: we want 1st record only (while is not wanted here)
               // The query will return 1 record; 
               // thus we, probably want to check for `Null` not for `dr.Read`:
               if (dr.Read() && !dr.IsDBNull(0)) {
                 textBox1.Text = (Convert.ToInt32(dr[0]) + 1).ToString();
               }
               else {
                 // Table is empty
               }
             }
           }
         }
         finally {
           // finally: rain or shine close the connection
           conn.Close();
         }
       }
