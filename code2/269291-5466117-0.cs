        private void Insert()
        {
            using (SqlConnection conn = new SqlConnection(ConnStr)) 
             {             
            string Command = "INSERT INTO [Countries] (CountryName, IsVisible) VALUES (@Name, @IsVisible)";    
          
            using (SqlCommand comm = new SqlCommand(Command, conn)) 
             {
            comm.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 20); 
            comm.Parameters["@Name"].Value = Name;
            comm.Parameters.Add("@IsVisible", System.Data.SqlDbType.Bit);                 comm.Parameters["@IsVisible"].Value = IsVisible;
            conn.Open(); 
            comm.ExecuteNonQuery();
             
            conn.Close();
            } 
    
    }
-----------------------------
    private void SelectInsert()
    {
          using (SqlConnection conn = new SqlConnection(ConnStr)) 
         {             
        string Command = "SELECT CountryName FROM [Countries] WHERE CountryName = @Name";              
        using (SqlCommand comm = new SqlCommand(Command, conn)) 
         {
        comm.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 20); 
        comm.Parameters["@Name"].Value = Name;
        conn.Open(); 
        if (comm.ExecuteScalar() == null)
        { 
           
               Insert(); //your save method
        
         }
        } 
    }
