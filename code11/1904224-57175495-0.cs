    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    dt1.Columns.Add("A");
    dt1.Columns.Add("B");
    dt1.Columns.Add("C");
    
    dt2.Columns.Add("X");
    dt2.Columns.Add("Y");
    dt2.Columns.Add("Z");
    
    dt1.Rows.Add("a", "a", "a");
    dt2.Rows.Add("b", "b", "b");
    
    private void Button1_Click(object sender, EventArgs e)
    {
        dataGridView1.DataSource = dt1;  // set datasource from dt1
    }
    
    private void Button2_Click(object sender, EventArgs e)
    {
           dataGridView1.DataSource = dt2; // set datasource from dt2
    }
