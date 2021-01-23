    static DataTable additems(string itema, string itemb, string itemc, string itemd, DataTable foo)
    {
        DataTable listitems = foo;
        if(foo == null)
        {
           listitems = new DataTable();
           listitems.Columns.Add("itema");
           listitems.Columns.Add("itemb");
           listitems.Columns.Add("itemc");
           listitems.Columns.Add("itemd");
        }
    
        // Add new items
        listitems.Rows.Add(itema, itemb, itemc, itemd);
    
        return listitems;
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        // add to data grid
        dataGridView1.DataSource = additems("New text", "Almonds", "Butter", "Salt", (DataTable)dataGridView1.DataSource); 
    }
