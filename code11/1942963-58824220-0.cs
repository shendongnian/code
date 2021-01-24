	public async void Button_Click(object sender, EventArg e)
	{
		await CheckItems(listViewMain.Items.Cast<ListViewItem>());
	}
	public async Task CheckItems(IEnumerable<ListViewItem> items)
	{
        // Capture the UI thread synchronization.
		var context = SynchronizationContext.Current;
		
		var tasks = new List<Task>();
		
		// create tasks.
		foreach (var row in items)
		{
			tasks.Add(Task.Run(() =>
			{
                // the lookup on a (probably) threadpool thread
				string html = Helpers.GetRequest(row.Text);
                // the processing here..
				var containsText = html.Contains(txtBoxFind.Text);
				
                // post the result (and touching gui items in the UI thread)
				context.Post(() =>
				{
					if (containsText)
					{
						row.SubItems[3].Text = "YES";
					}
					else
					{
						row.SubItems[3].Text = "NO";
					}
				});
					
			}));
		}
		
		// wait for them
		await Task.WhenAll(tasks);
	}
