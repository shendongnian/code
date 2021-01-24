    private async void StartParseButtonClick(object sender, EventArgs e)
    {
        // disable button (we are on UI thread)
        var startParseButton = sender as Button;
        startParseButton.Enabled = false;
        try
        {
            // copy just in case if someone will add new item while we iterating over
            var items = listView1.Items.OfType<ListViewItem>().ToList();
            foreach (var item in items)
                await Parse(item); // this will be invoked in worker thread
        }
        finally
        {
            // enable button finally (we are on UI thread)
            startParseButton.Enabled = true;
        }
    }
    private async Task Parse(ListViewItem item)
    {
        // slowwww work (we are on worker thread)
        await Task.Delay(500);
    }
