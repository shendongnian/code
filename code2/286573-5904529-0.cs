    // A custom delegate like MyItemClickedHandler, or you could make a Func<> or Action<>
    public event MyItemClickedHandler ItemClickedEvent;
    public void ItemClicked(object sender, EventArgs e)
    {
        if(ItemClickedEvent != null)
          ItemClickedEvent(); // Your delegate could pass parameters if needed
    }
