    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        string is1Checked;
        if (NavigationContext.QueryString.TryGetValue("chk1", out is1Checked))
        {
            if (bool.Parse(is1Checked))
            {
                //
            }
        }
        string is2Checked;
        if (NavigationContext.QueryString.TryGetValue("chk2", out is2Checked))
        {
            if (bool.Parse(is2Checked))
            {
                //
            }
        }
    }
