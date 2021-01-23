    //Create DataTable
    
    DataTable dt = new DataTable();
    
    //Put some columns in it.
    
    dt.Columns.Add(new DataColumn("Item #", typeof(int)));
    
    dt.Columns.Add(new DataColumn("Contract Number", typeof(string)));
    
    dt.Columns.Add(new DataColumn("Customer Name", typeof(string)));
    
    // Create the record
    
    DataRow dr = dt.NewRow();
    
    dr["Item #"] = i;
    
    dr["Customer Name"] = xmn2[1].InnerText;  //value from textbox on screen
    
    dr["Contract Number"] = xmn4[1].InnerText; //value from textbox on screen
    
    dt.Rows.Add(dr);
    
    //Bind the GridView to the data in the data table for display.
    
    this.GridView1.Visible = true;
    
    GridView1.DataSource = dt;
    
    GridView1.DataBind();
