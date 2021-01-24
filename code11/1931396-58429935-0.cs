    public override void ViewDidAppear(bool animated) {
        base.ViewDidAppear(animated);
        SetNavigationButtonsPage();
    }
    private void SetNavigationButtonsPage()
    {
        var att = new UITextAttributes
        {
            Font = UIFont.FromName("FontAwesome5Pro-Light", 16),
        };
        var navigationItems = (this as UINavigationController).NavigationBar.Items;
        List<UIBarButtonItem> barButtonItems = new List<UIBarButtonItem>();
        foreach (UINavigationItem item in navigationItems)
        {
            barButtonItems.AddRange(item.LeftBarButtonItems);
            barButtonItems.AddRange(item.RightBarButtonItems);
        }
        foreach (UIBarButtonItem bbItem in barButtonItems)
        {
            //change appearance for each bbItem
            bbItem.SetTitleTextAttributes(att, UIControlState.Normal);
        }
    }
