    //Creates a new async trigger
    AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
            
    //Sets the control that will trigger a post-back on the UpdatePanel
    trigger.ControlID = "btnCommit";
    //Sets the event name of the control
    trigger.EventName = "Click";
    //Adds the trigger to the UpdatePanels' triggers collection
    pnlMain.Triggers.Add(trigger);
