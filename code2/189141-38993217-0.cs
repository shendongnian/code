    protected override void WndProc(ref Message message)
    {
        const int WM_NCHITTEST = 0x0084;
        const int HTCLIENT = 0x01;
        if (message.Msg == WM_NCHITTEST)
        {
            message.Result = new IntPtr(HTCLIENT);
            return;
        }
        base.WndProc(ref message);
    }
