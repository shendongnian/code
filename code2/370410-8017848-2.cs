    DataSet dataset = new DataSet();
    using (SqlConnection connection = 
        new SqlConnection(connectionString))
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = new SqlCommand(
            "select * from alert", connection);
        adapter.Fill(dataset, "authenticate");
    }
    // Load Data from the DataSet into the ListView
    private void LoadList()
    {
        // Get the table from the data set
        DataTable dtable = dataset.Tables["authenticate"];
    
        // Clear the ListView control
        listView1.Items.Clear();
    
        // Display items in the ListView control
        for (int i = 0; i < dtable.Rows.Count; i++)
        {
 
            DataRow drow = dtable.Rows[i];
    
            // Define the list items
            ListViewItem lvi = new ListViewItem(drow["name"].ToString());
            lvi.SubItems.Add (drow["location"].ToString());
            lvi.SubItems.Add (drow["type"].ToString());
            lvi.SubItems.Add (drow["memberID"].ToString());
            lvi.SubItems.Add (drow["imageExtension"].ToString());
            // Add the list items to the ListView
            listView1.Items.Add(lvi);
        }
    }
