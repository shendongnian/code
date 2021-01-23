        WindowsFormsHost host =new WindowsFormsHost();
        var toolTip1 = new System.Windows.Forms.ToolTip();
        toolTip1.AutoPopDelay = 5000;
        toolTip1.InitialDelay = 1000;
        toolTip1.ReshowDelay = 500;
        toolTip1.ShowAlways = true;
        toolTip1.IsBalloon = true;
        toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
        toolTip1.ToolTipTitle = "Title:";
        System.Windows.Forms.TextBox tb = new System.Windows.Forms.TextBox();
        tb.Text="Go!";
        toolTip1.SetToolTip(tb, "My Info!");
        host.Child = tb;
        grid1.Children.Add(host);  //windowsForm textBox container
