    string connectionstring = "Some connection sting";
    string sql = "Select reporttime, datapath from sometable";
    System.Data.DataTable t = new System.Data.DataTable();
    System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter(sql, connectionstring);
    ad.Fill(t);
    
    chart1.DataSource = t;
    
    chart1.Series["Series1"].XValueMember = "reporttime";  
    chart1.Series["Series1"].YValueMembers = "datapath"; 
