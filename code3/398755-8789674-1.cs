    private void LoadList()
    {
        // Get the table from the data set
        DataTable dtable = _DataSet.Tables["Titles"];
    
        // Clear the ListView control
        listView1.Items.Clear();
    
        // Display items in the ListView control
        for (int i = 0; i < dtable.Rows.Count; i++)
        {
            DataRow drow = dtable.Rows[i];
    
            // Only row that have not been deleted
            if (drow.RowState != DataRowState.Deleted)
            {
                // Define the list items
                ListViewItem lvi = new ListViewItem(drow["title"].ToString());
                lvi.SubItems.Add (drow["title_id"].ToString());
                lvi.SubItems.Add (drow["price"].ToString());
                lvi.SubItems.Add (drow["pubdate"].ToString());
    
                // Add the list items to the ListView
                listView1.Items.Add(lvi);
            }
        }
    } 
