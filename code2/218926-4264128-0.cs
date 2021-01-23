    protected void Button1_Click(object sender, EventArgs e) 
        { 
            try 
            { 
                SqlConnection myConn1 = new SqlConnection("Server=localhost;Database=testcase;Integrated Security=SSPI"); 
                SqlCommand myCmd1 = new SqlCommand("select casename,skey from casetype where skey=?", myConn1); 
                myConn1.Open();
    String type = DropDownList3.SelectedItem.Text; 
                myCmd1.Parameters.AddWithValue("?", type); 
                SqlDataReader myReader1 = myCmd1.ExecuteReader(); 
                 
            } 
            catch (Exception exw) 
            { 
                Response.Write(exw.StackTrace); 
            } 
     
        } 
