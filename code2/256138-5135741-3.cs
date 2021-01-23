    protected override void WndProc(ref Message message) 
    { 
        const int WM_NCHITTEST = 0x0084; 
        if (message.Msg == WM_NCHITTEST)
        {
            return; 
        }
			
        base.WndProc(ref message);
    }
