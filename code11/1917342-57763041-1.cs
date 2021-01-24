    if (feedsList.SelectedItem != null)
    {
        feedTxt.Text = "";
        string url = feedsList.GetItemText(feedsList.SelectedItem);
        Uri myUri = new Uri(url, UriKind.Absolute);
        XmlReader reader = XmlReader.Create(url);
        SyndicationFeed feed = SyndicationFeed.Load(reader);
    
        foreach (SyndicationItem item in feed.Items)
        {
            // Store current content length of RichTextBox
            int currentLength = feedTxt.Length;
            
            // Append new content
            feedTxt.Text += item.Title.Text + "\n\n";
            feedTxt.Text += item.Summary.Text + "\n\n";
    
            // Set the font for Title using selection
            feedTxt.SelectionStart = currentLength.Length;
            feedTxt.SelectionLength = item.Title.Text.Length;
            feedTxt.SelectionFont = new System.Drawing.Font("Tahoma", 24);
    
            // Set the font for Summary using selection
            feedTxt.SelectionStart = currentLength + item.Title.Text.Length;
            feedTxt.SelectionLength = item.Summary.Text;
            feedTxt.SelectionFont = new System.Drawing.Font("Arial", 16);
        }
    }
