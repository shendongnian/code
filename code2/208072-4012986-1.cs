	private static void RepaintListView(ListView lw)
	{
		var colored = false;
		foreach (ListViewItem item in lw.Items)
		{
			item.BackColor = colored ? Color.LightBlue : Color.White;
			colored = !colored;
		}
	}
