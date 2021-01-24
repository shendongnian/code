    private void btnPersonalInfo_Click(object sender, EventArgs e) 
    { 
         string thisuser = "example";  // example value
         sqlcon.Open(); 
         string query = "SELECT score1,score2,score3 FROM tblLogin WHERE username = '" + thisuser + "'"; 
         SqlCommand sda = new SqlCommand(query, sqlcon); 
         SqlDataReader da = sda.ExecuteReader(); 
         if (thisuser == da.GetValue(1).ToString()) 
         { 
             while (da.Read()) 
             { 
                 MessageBox.Show("Your Personal Info are: sda.GetValue(3).ToString()"); 
             } 
         } 
         sqlcon.Close();
    }
