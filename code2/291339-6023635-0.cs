    // Form 1
    while (rdr.Read())            
    {                
       Page.Session["UserName"] = rdr["UserName"].ToString(); 
       Label1.Text = "Welcome " + rdr["UserName"].ToString() + ". Press the Play Button to Play";    
       Button3.Enabled = true;            
    }
    
    // Form 2        
    string username = Page.Session["UserName"].ToString(); // Retrieve in form 2
