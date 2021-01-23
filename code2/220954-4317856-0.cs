    private void listView2_SelectedIndexChanged(object sender, EventArgs e) 
    { 
        string proj;
        if (listView2.SelectedItems.Count > 0)
            proj = listView2.SelectedItems[0].ToString(); 
        else
            proj = string.Empty;
    } 
