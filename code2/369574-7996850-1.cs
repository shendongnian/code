    try 
    { 
     SqlConnection xconn = new SqlConnection(); 
     xconn.ConnectionString = @" Data Source=servername; Database=master; Trusted_Connection=yes";
     SqlCommand ycmd = new SqlCommand ("select * from tablename where column1 = @name", xconn); 
     ycmd.Parameters.Add("@name", dropdownlist.SelectedValue); 
     SqlDataAdapter da = new SqlDataAdapter(ycmd);
     
     DataTable dt = new DataTable(); 
     da.Fill(dt); 
     gridview.DataSource = dt; 
     gridview.DataBind(); 
    } 
    catch(Exception ex) 
    { 
      label.Text = ex.Message + "\n" + ex.StackTrace; 
    }
