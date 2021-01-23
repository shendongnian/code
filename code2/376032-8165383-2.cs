    protected void lnkDelete_Click(object sender, EventArgs e)  
    { 
            LinkButton lnk = (LinkButton)sender; 
            string stid = lnk.CommandArgument.ToString(); 
            SqlConnection conn = new SqlConnection(<put your connectionstring here>);
            string sql = string.Format("DELETE FROM [UserDB] where Employee like '%{0}%'",stid);
            SqlCommand cmd = new SqlCommand(sql,conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();   
            BindTheGridView();
              
                //or you can use SelectCommand of your SqlDataSource1 and can bind again simply.
    } 
    
