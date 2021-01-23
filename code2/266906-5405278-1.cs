    private SolutionEvents solutionEvents;
    public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
    {
        Globals.DTE = (DTE2)application;
        Globals.Addin = (AddIn)addInInst;
        solutionEvents = Globals.DTE.Events.SolutionEvents;
        solutionEvents.Opened += new _dispSolutionEvents_OpenedEventHandler(SolutionEvents_Opened);
        solutionEvents.BeforeClosing += new _dispSolutionEvents_BeforeClosingEventHandler(SolutionEvents_BeforeClosing);
    }
