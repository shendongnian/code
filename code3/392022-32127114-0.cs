    ToolStripMenuItem menuItem = new ToolStripMenuItem("MyMenu");
    MonthCalendar calControl = new MonthCalendar();
    ToolStripControlHost controlHost = new ToolStripControlHost(calControl);
    controlHost.Margin = Padding.Empty;
    controlHost.Padding = Padding.Empty;
    ContextMenuStrip1.Items.Add(menuItem);
    ToolStripDropDown dropDown = new ToolStripDropDown();
    dropDown.Items.Add(controlHost);
    menuItem.DropDown = dropDown;
