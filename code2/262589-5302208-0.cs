    List<CormantRadPane> panesToSave = new List<CormantRadPane>();
    
    foreach (KeyValuePair<string, RadPaneSetting> paneState in RadControlStates.PaneStates)
    {
        CormantRadPane pane = Utilities.FindControlRecursive(Page, paneState.Key) as CormantRadPane;
        RadControlSave.SavePane(pane);
        panesToSave.Add(pane);
    }
