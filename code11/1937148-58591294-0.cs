    if (mbItem.HideExtraInfo == true)
    {
        mbButton.Click += ShowControls;
    }
    else
    {
        mbButton.Click += HideControls;
    }
    private void ShowControls(object sender, EventArgs e) => ShowOrHideControls(sender, e, true);
    private void HideControls(object sender, EventArgs e) => ShowOrHideControls(sender, e, false);
    private void PageEnd()
    {
        //When moving to the next page, unsubscribe from the events
        foreach (MenuButton mbItem in mbMenuButtonsList)
        {
            mbItem.Click -= ShowControls;
            mbItem.Click -= HideControls;
        }
    }
