`csharp
	public async Task DoSomething()
	{
        // Process the items parallel
		await Task.WhenAll(listViewMain.Items.Cast<ListViewItem>().Select(async row =>
		{
			// wrap the long running call in a async Task
			string html = await Task.Run(() => Helpers.GetRequest(row.Text));
			
            // no need for context capturing and invokes, this is running on the UI thread
			var containsText = html.Contains(txtBoxFind.Text);
			if (containsText)
			{
				row.SubItems[3].Text = "YES";
			}
			else
			{
				row.SubItems[3].Text = "NO";
			}
		}));
	}
`
It would be even better when you can make `Helpers.GetRequest(row.Text)` async, the you could do:
`csharp
	public async Task DoSomething()
	{
        // Process the items parallel
		await Task.WhenAll(listViewMain.Items.Cast<ListViewItem>().Select(async row =>
		{
			// wrap the long running call in a async Task
			string html = await Helpers.GetRequestAsync(row.Text);
			
            // no need for context capturing and invokes, this is running on the UI thread
			var containsText = html.Contains(txtBoxFind.Text);
			if (containsText)
			{
				row.SubItems[3].Text = "YES";
			}
			else
			{
				row.SubItems[3].Text = "NO";
			}
		}));
	}
`
but we need to see the code of `Helpers.GetRequest(row.Text)` to assist you with that.
