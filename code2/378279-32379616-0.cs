    ToolTip tt = new ToolTip();
    private void someObjectName_MouseHover(object sender, EventArgs e) {
        tt = new ToolTip
        {
            AutoPopDelay = 15000,  // Warning! MSDN states this is Int32, but anything over 32767 will fail.
            ShowAlways = true,
            ToolTipTitle = "Symbolic Name",
            InitialDelay = 200,
            ReshowDelay = 200,
            UseAnimation = true
        };
        tt.SetToolTip(this.someObjectName, "This is a long message");
    }
