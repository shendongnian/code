    AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
    trigger.ControlID = b.UniqueID;
    trigger.EventName = "Click";
    yourUpdPanel.Triggers.Add(trigger);
    
    ScriptManager.RegisterAsyncPostBackControl(b);
