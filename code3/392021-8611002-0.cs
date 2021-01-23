    MonthCalendar calControl = new MonthCalendar();
    ToolStripControlHost controlHost = new ToolStripControlHost(calControl);
    controlHost.Margin = Padding.Empty;
    controlHost.Padding = Padding.Empty;
    ToolStripDropDown toolDrop = new ToolStripDropDown();
    toolDrop.Padding = Padding.Emtpy;
    toolDrop.Margin = Padding.Empty;
    toolDrop.Items.Add(controlHost);
    toolDrop.Show(this, location);
