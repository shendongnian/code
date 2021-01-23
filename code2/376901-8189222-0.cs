    private const int WM_DEVICECHANGE = 0x219;
    protected override void WndProc(ref Message m)
    {
        base.WndProc(m);
        if (m.Msg == WM_DEVICECHANGE)
        {
            // Check m.wParam to see exactly what happened
        }
    }
