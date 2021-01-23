    private void displayListInTextBlock(List<Item> items)
    {
        foreach (Item item in items)
        {
            rssDisplayer.Text += item.ToString() + Environment.NewLine;
        }
    }
