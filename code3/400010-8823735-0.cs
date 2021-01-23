    public void OnRefreshButtonClicked(object *sender)
    {
        myListView.SuspendLayout();
    
        foreach (ListViewItem itm in myListView.Items)
        {
            RefreshItem(itm);
        }
 
        myListView.ResumeLayout();
    }
