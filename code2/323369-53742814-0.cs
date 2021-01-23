    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            // reduce flickering when switching mdi child forms (see also WndProc)
            cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED (which is essentially double buffered)
            return cp;
        }
    }
        
