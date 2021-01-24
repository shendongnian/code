    public void ShowDocument()
    {
        string filename = string.Empty;
        string contentType = string.Empty;
        byte[] bytes = null;
        
        using (SqlConnection con = new SqlConnection(constr))
        {
            con.Open();
    
            using (SqlCommand com = new SqlCommand("SELECT * FROM FileUploader2", con))
            {
                 using (SqlDataReader reader = com.ExecuteReader())
                 {
                     if (reader.Read())
                     {
                         filename = (string)reader["Name"];
                         contentType = (string)reader["ContentType"];
                         bytes = (byte[])reader["Data"];
                     }
                 }
             }
         }
        Response.ContentType = contentType; 
        Response.AddHeader("Content-Disposition", "attachment; filename=" + filename); 
        Response.OutputStream.Write(bytes, 0, bytes.Length); 
        Response.Flush(); 
    }
