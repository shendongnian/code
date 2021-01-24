    if (feedsList.SelectedItem != null)
    {
        feedTxt.Text = "";
        string url = feedsList.GetItemText(feedsList.SelectedItem);
        Uri myUri = new Uri(url, UriKind.Absolute);
        XmlReader reader = XmlReader.Create(url);
        SyndicationFeed feed = SyndicationFeed.Load(reader);
    
    
        // Create List to store our selections
        List<ArticleSelection> articleSelections = new List<ArticleSelection>();
    
        // Loop all incoming content
        foreach (SyndicationItem item in feed.Items)
        {
            // Store current content length of RichTextBox
            int currentLength = feedTxt.Length;
            
            // Append new content
            feedTxt.Text += item.Title.Text + "\n\n";
            feedTxt.Text += item.Summary.Text + "\n\n";
    
            // Calculate selection
            articleSelections.Add(new ArticleSelection()
            {
                TitleStart = currentLength,
                TitleEnd = feed.Item1.Length,
                SummaryStart = currentLength + feed.Item1.Length,
                SummaryEnd = feedTxt.Text - currentLength // This accounts for new lines above
            }); ; 
        }
    
    
        // Loop through the content and style it
        foreach (ArticleSelection selection in articleSelections)
        { 
            // Set the selection for Title
            txtTest.SelectionStart = selection.TitleStart;
            txtTest.SelectionLength = selection.TitleEnd;
            txtTest.SelectionFont = new Font("Tahoma", 24);
    
            // Set the selection for Summary
            txtTest.SelectionStart = selection.SummaryStart;
            txtTest.SelectionLength = selection.SummaryEnd;
            txtTest.SelectionFont = new Font("Arial", 14);
        }
    
        // Remove Selection
        txtTest.DeselectAll();
    }
