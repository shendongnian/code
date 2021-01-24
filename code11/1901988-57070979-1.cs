    public void Initialize(IList<string> items)
    {
        // just a shorter way for the same condition
        if (items?.Any() ?? false)
        {
            this.ItemsSource = Items.Aggregate((x, y) => x + "\r\n" + y);
        } // I like to always use code blocks for conditions etc'. I find it more readable.
    }
