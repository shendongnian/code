    UpdatePanel updatePanel = new UpdatePanel();
    updatePanel.UpdateMode = UpdatePanelUpdateMode.Conditional;
    
    gridView.OnRowCommand = "GridViewRowCommand";
    AsyncPostbackTrigger newTrigger = new AsyncPostbackTrigger();
    newTrigger.ControlID = gridView.ControlID;
    updatePanel.Triggers.Add(newTrigger);
