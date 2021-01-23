    private readonly ISession _session;
    public frmPlayerViewer()
    {
        InitializeComponent();
        // bail out if we're in the designer
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        {
                return;
        }
        _session = Program.OpenEvtSession(FlushMode.Commit);
    }
