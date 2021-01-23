    const int WM_KEYDOWN = 0x100;
    const int WM_KEYUP = 0x101;
    protected override bool ProcessKeyPreview(ref Message m)
    {
        if (m.Msg == WM_KEYDOWN && (Keys)m.WParam == Keys.ControlKey)
        {
            //Do something
        }
        else if (m.Msg == WM_KEYUP && (Keys)m.WParam == Keys.ControlKey)
        {
            //Do something
        }
 
        return base.ProcessKeyPreview(ref m);
    }
