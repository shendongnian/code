    UtilStk.StkRoot.OnStkObjectAdded += new IAgStkObjectRootEvents_OnStkObjectAddedEventHandler(TallyScenarioObjects);
    private void TallyScenarioObjects(object sender)
    {
        DoStuff();
    }
    
    private void DoStuff() { ... }
    
    private void AnotherMethod()
    {
        DoStuff();
    }
