    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        string isChecked;
        if (NavigationContext.QueryString.TryGetValue("chkd", out isChecked))
        {
            if (bool.Parse(isChecked))
            {
                //
            }
        }
    }
