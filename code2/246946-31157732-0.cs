    // Contains and propagates information about current page
    private SwitchCondition<int> settingPageCondition;
    // Controls state of specific controls basing on given SwitchCondition
    private VisualStateSwitchController<int> settingPageController;
    
    // (...)
    private void InitializeActions()
    {
        // Initialize with possible options
        settingPageCondition = new SwitchCondition<int>(0, 1);
        settingPageController = new VisualStateSwitchController<int>(
            null,                  // Enabled is not controlled
            null,                  // Checked is not controlled
            settingPageCondition,  // Visible is controller by settingPageCondition
            new SwitchControlSet<int>(0, pGeneral),   // State 0 controls pGeneral
            new SwitchControlSet<int>(1, pParsing));  // State 1 controls pParsing
    }
    // (...)
    public void MainForm()
    {
        InitializeComponent();
        InitializeActions();
    }
    // (...)
    // Wat to set specific page
    settingPageCondition.Current = 0;
