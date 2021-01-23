    // Get the current display mode of the WPM
    WebPartManager wp = WebPartManager.GetCurrentWebPartManager(Page);
    String mode = wp.DisplayMode.Name;
    // Enable validation in BrowseDisplayMode only
    if (wp.DisplayMode == WebPartManager.BrowseDisplayMode)
    {
        reqJournal.Enabled = true;
    }
    else
    {
        reqJournal.Enabled = false;
        lblMsg.Text = "<strong>" + mode + " mode</strong>: Validation is disabled.";
    }
