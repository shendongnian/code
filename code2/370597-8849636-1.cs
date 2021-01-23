    private delegate ListView.ListViewItemCollection GetItems(ListView lstview);
        
	private ListView.ListViewItemCollection getListViewItems(ListView lstview)
	{
		ListView.ListViewItemCollection temp = new ListView.ListViewItemCollection(new ListView());
		if (!lstview.InvokeRequired)
		{
			foreach (ListViewItem item in lstview.Items)
			temp.Add((ListViewItem)item.Clone());
			return temp;
		}
		else
			return (ListView.ListViewItemCollection)this.Invoke(new GetItems(getListViewItems), new object[] { lstview });
	}
