    UtilStk.StkRoot.OnStkObjectAdded += new IAgStkObjectRootEvents_OnStkObjectAddedEventHandler(TallyScenarioObjects);
    
    private void TallyScenarioObjects(object sender)
    {
         DoTally(....);
    }
    private void DoTally(....)
    {
    }
