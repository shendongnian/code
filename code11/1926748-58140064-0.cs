    public void SetTabVisibility(MessageTabVisibility msgTabVisibility)
    {
        Console.WriteLine("Tabs Set Visiblity Callback");
        VisibilitySuitesReportTab = (bool) msgTabVisibility.SuitesReportVisible;
        VisibilityTenantRankingsTab = (bool) msgTabVisibility.TenantRankingsVisible;
        VisibilityIndustryBreakdownTab = (bool) msgTabVisibility.IndustryReportVisible;
        VisibilitySubmarketBreakdownTab = (bool)msgTabVisibility.SubmarketBreakdownVisible;
        Messenger.Default.Unregister<MessageTabVisibility>(this);
        Console.WriteLine("Refresh");
        OnPropertyChanged("VisibilitySuitesReportTab");
        OnPropertyChanged("VisibilityTenantRankingsTab");
        OnPropertyChanged("VisibilityIndustryBreakdownTab");
        OnPropertyChanged("VisibilitySubmarketBreakdownTab");
    }
