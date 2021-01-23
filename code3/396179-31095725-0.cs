    private void Initialize()
    {
        split = new SplitContainer();
        ((Panel)split.Panel1).VisibleChanged += splitPanel1_Collapsed;
    }
    private void splitPanel1_Collapsed(object sender, EventArgs e)
    {
        var panel = (SplitterPanel)sender;
        var panelCollapsed = !panel.Visible;
    }
