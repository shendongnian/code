    private delegate void AddListItem(string item);
    private void AddListBoxItem(string item)
    {
        if (this.lbPrimes.InvokeRequired)
        {
            AddListItem d = new AddListItem(item);
            this.Invoke(d, new object[] { item});
        }
        else
        {
            this.lbPrimes.Items.Add(item);
        }
    }
