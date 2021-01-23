    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
    
        NavigationContext.QueryString.TryGetValue("idx", out m_Link);
        NavigationContext.QueryString.TryGetValue("title", out m_Title);
    }
