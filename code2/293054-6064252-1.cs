    void SetSecondTab()
    {
        tcTabs.SelectedTab = secondTab;
    }
    
    void SwitchTabsFromThread()
    {
        this.Invoke(new Action(() => { SetSecondTab(); }));
    }
