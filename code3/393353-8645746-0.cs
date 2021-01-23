    void AddNewTab()
    {
        var newTab = new TabAViewModel();
        Tabs.Add(newTab);
        SelectedTabIndex = Tabs.IndexOf(newTab);
    }
