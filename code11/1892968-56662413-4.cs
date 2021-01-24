    string NewDate = DateTime.Now.ToString("dd/MM/yyyy"); 
    public void GridBind() 
    { 
      dbcon.Open();  
      SqlCommand cmd = new SqlCommand("select Id,FORMAT(Date,'dd/MM/yyyy') AS Date,Subject,Disc from NoticeBoard where school_id='" + a + "' and FORMAT(Date,'dd/MM/yyyy')= '" + NewDate + "' , dbcon); 
    
      SqlDataAdapter sda = new SqlDataAdapter(cmd); 
      DataSet ds = new DataSet(); 
      sda.Fill(ds); 
      gvTeacher.DataSource = ds; 
      gvTeacher.DataBind(); 
      dbcon.Close(); 
    } 
