    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        if (phoneAppService.State.ContainsKey("tmpPlayerName"))
        {
            object pName;
            if (phoneAppService.State.TryGetValue("tmpPlayerName", out pName))
            {
                tempPlayerName = (string)pName;
            }
            highScorePlayerList.Add(tempPlayerName);
        }
    }
