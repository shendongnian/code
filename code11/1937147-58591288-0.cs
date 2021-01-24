    private void PageStart()
    {
        //Subscribe to the necessary event when a page is first loaded
        foreach (MenuButton mbItem in mbMenuButtonsList)
        {
            if (mbItem.HideExtraInfo == true)
            {
                mbButton.Click += true_handler;
            }
            else
            {
                mbButton.Click += false_handler;
            }
        }
    }
    void true_handler(object sender, EventArgs args)
    {
        ShowOrHideControls(sender, e, true);
    }
    void false_handler(object sender, EventArgs args)
    {
        ShowOrHideControls(sender, e, false);
    }
    
    private void PageEnd()
    {
        //When moving to the next page, unsubscribe from the events
        foreach (MenuButton mbItem in mbMenuButtonsList)
        {
            if (mbItem.HideExtraInfo == true)
            {
                mbButton.Click -= true_handler;
            }
            else
            {
                mbButton.Click -= false_handler;
            }
        }
    }
