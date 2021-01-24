    if (feedsList.SelectedItem != null)
    {
        feedTxt.Text = "";
        string url = feedsList.GetItemText(feedsList.SelectedItem);
        Uri myUri = new Uri(url, UriKind.Absolute);
        XmlReader reader = XmlReader.Create(url);
        SyndicationFeed feed = SyndicationFeed.Load(reader);
    
        foreach (SyndicationItem item in feed.Items)
        {
            feedTxt.Text = feedTxt.Text + item.Title.Text;
            feedTxt.Text = feedTxt.Text + "\n\n" + item.Summary.Text + "\n\n";
        }
    
        // Set the selection for Title
        feedTxt.SelectionStart = 0;
        feedTxt.SelectionLength = item.Title.Text.Length;
        feedTxt.SelectionFont = new System.Drawing.Font("Tahoma", 24);
    
        // Set the selection for Summary
        feedTxt.SelectionStart = item.Title.Text.Length + 1; 
        feedTxt.SelectionLength = feedTxt.Length;
        feedTxt.SelectionFont = new System.Drawing.Font("Arial", 16);
    }
