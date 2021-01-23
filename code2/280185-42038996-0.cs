    bool handled;
    private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
    	if (!handled)
    	{	handled = true;
    		Application.Idle += SelectionChangeDone;   }
    }
    
    private void SelectionChangeDone(object sender, EventArgs e) {
    	Application.Idle -= SelectionChangeDone;
    	handled = false;
    	
    	ListView.SelectedListViewItemCollection collection = this.listView1.SelectedItems;
        if (collection.Count == 0)
            this.label2.Text = "Unselected all!"
        foreach (ListViewItem item in collection)
            getSideInformation(item.Text);
    }
