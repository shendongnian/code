        ToolTip toolTip1 = new ToolTip();
        toolTip1.AutoPopDelay = 5000;
        toolTip1.InitialDelay = 1000;
        toolTip1.ReshowDelay = 500;
        toolTip1.ShowAlways = true;
        toolTip1.IsBalloon = true;
        toolTip1.ToolTipIcon = ToolTipIcon.Info;
        toolTip1.ToolTipTitle = "Title:";
        toolTip1.SetToolTip(this.textBox1, "My Info!");
