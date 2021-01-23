    this.Activate();
    
    ToolTip toolTip = new ToolTip();
    toolTip.ToolTipTitle = "Info";
    toolTip.ToolTipIcon = ToolTipIcon.Info;
    toolTip.UseFading = true;
    toolTip.UseAnimation = true;
    toolTip.IsBalloon = true;
    toolTip.ShowAlways = true;
    toolTip.AutoPopDelay = 5000;
    toolTip.InitialDelay = 1000;
    toolTip.ReshowDelay = 500;
    toolTip.Show("This is button1", button1, 10000);
