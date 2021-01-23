    int i=dataGridView1.CurrentRow.Index;
    string ID=dataGridView1.Row[i].Cell["id"].Value.ToString();
    
    // Now you can adopt the table value to your query strin
    string strData="SqlDataAdapter da=new SqlDataAdapter ("select * from Table1 Where ID='"+ID+"',cn);
    DataTable dt=new DataTable();
    da.Fill(dt);
    
    //Now bind the data to corresponding controls.
    txtID.Text=dt.Row[0]["ID"].ToString();
    
    
    //Happy Coding
