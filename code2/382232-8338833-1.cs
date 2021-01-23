    SqlCommand SelectCmmand = new SqlCommand(query, conn);            
    SqlDataReader rd1;    
    conn.Open(); 
           
    rd1 = SelectCmmand.ExecuteReader();
    DataTable dt1 = new DataTable();
    dt1.Load(rd1);
    
    conn.Close();
    SqlCommand SelectCmmand = new SqlCommand(query, conn);            
    SqlDataReader rd2;            
    conn.Open();
    
    rd2 = SelectCmmand.ExecuteReader();
        DataTable dt2 = new DataTable();
        dt2.Load(rd2);
    
    conn.Close();
