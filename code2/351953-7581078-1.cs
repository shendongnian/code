            System.Windows.Forms.Integration.WindowsFormsHost host =new System.Windows.Forms.Integration.WindowsFormsHost();
    
            ToolTip toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Title:";
            System.Windows.Forms.Button bb = new System.Windows.Forms.Button();
            bb.Text="Help!";
            toolTip1.SetToolTip(bb, "My Info!");
            host.Child = bb;
            grid1.Children.Add(host);
