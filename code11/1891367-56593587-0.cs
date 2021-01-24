       string query = 
         @"SELECT ID,
                  Nome,
                  Cognome,
                  Email,
                  CodiceFiscale 
             FROM Persona 
            WHERE ID = @id";
       using (SqlConnection con = new SqlConnection(...))
       {         
           con.Open();
           using SqlCommand cmd = new SqlCommand(query, con) 
           {
               // I doubt if you want empty Id here. 
               cmd.Parameters.AddWithValue("@ID", Request.QueryString.Get("ID_Persona")); 
               using (var reader = cmd.ExecuteReader())
               {
                   if (reader.Read()) 
                   {
                       TextBox1.Text  = Convert.ToString(reader["Nome"]); 
                       TextBox15.Text = Convert.ToString(reader["Cognome"]); 
                       TextBox20.Text = Convert.ToString(reader["Email"]); 
                       TextBox22.Text = Convert.ToString(reader["CodiceFiscale"]);   
                   }
               }
           }
