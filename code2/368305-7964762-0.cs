    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        if (NavigationContext.QueryString.ContainsKey("template"))
        {
            var template = NavigationContext.QueryString["template"];
            switch (template)
            {
                case "small"
                    _List.ItemTemplate = Resources["SmallImageTemplate"] as ContentTemplate;
                case "big"
                    _List.ItemTemplate = Resources["BigImageTemplate"] as ContentTemplate;
            }
        }
    }
