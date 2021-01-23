        SqlConnection conn = new SqlConnection("Server=localhost;" + "Database=DB;User ID=aaaa;" + "Password=aaaa");              
    conn.Open();
    SqlCommand cmd = new SqlCommand("Your Query", conn);//Put your query here
    SqlDataReader reader = cmd.ExecuteReader();              
    while (reader.Read()) 
    {                 
    employeesLabel.Text += reader["Name"] + "<br />"; 
    } 
    reader.Close();             
    conn.Close(); 
