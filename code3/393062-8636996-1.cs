    private void displayListInTextBlock(List<string> items)
    {
        foreach (string item in items)
        {
            rssDisplayer.Text += item + Environment.NewLine;
        }
    }
