    ListView.SelectedListViewItemCollection listItems= 
    			this.myListView.SelectedItems;
    		
    	    foreach ( ListViewItem item in listItems)
    		{
    			MessageBox.Show(item.SubItems[0].Text);
    			MessageBox.Show(item.SubItems[1].Text);
    		}
	
