    public Loader()
    {
        var menu = new ContextMenuStrip();
        var menuItem = menu.Items.Add("Set Complete");
        menuItem.Click += OnMenuItemSetCompleteClick;
        menuItem = menu.Items.Add("Set Review");
        menuItem.Click += OnMenuItemSetReviewClick;
        menuItem = menu.Items.Add("Set Missing");
        menuItem.Click += OnMenuItemSetMissingClick;
    }
    private void OnMenuItemSetCompleteClick(object sender, EventArgs e)
    {
        // Do something
    }
    private void OnMenuItemSetReviewClick(object sender, EventArgs e)
    {
        // Do something
    }
    private void OnMenuItemSetMissingClick(object sender, EventArgs e)
    {
        // Do something
    }
