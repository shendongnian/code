    private const int WM_PASTE = 0x0302;
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_PASTE)
        {
            //Paste Event
        }
    }
