    public void LoadActivityData
        {
            string cnString = ConfigurationManager.ConnectionStrings["connectionstringname"].ConnectionString;
    
            MySqlConnection myConn = new MySqlConnection(cnString);
    
            DataSet dsActivity = new DataSet();
            string selectStr = "SELECT * FROM YourActivityTable";
           
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectStr, myConn);
    
            adapter.Fill(dsActivity, "Activities");
    
            grdView1.DataSource = dsActivity;
            
        }  
