    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        //do nothing
    }
    protected override void OnMove(EventArgs e)
    {
        RecreateHandle();
    }
    // Override the CreateParams property:
    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.ExStyle = 0x00000020; //WS_EX_TRANSPARENT
            return cp;
        }
    }
