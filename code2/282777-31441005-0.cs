    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    protected override void WndProc(ref Message message)
    {
        base.WndProc(ref message);
        if (message.Msg == 0x6)
        {
            int highOrderWord = (int)((message.WParam.ToInt32() & 0xFFFF0000) >> 16);
            bool minimized = highOrderWord != 0;
            bool activating = message.WParam != IntPtr.Zero;
            if (activating && !minimized)
            {
                this.FocusBrowserElement();
            }
        }
    }
    
    
    private void FocusBrowserElement()
    {
        if (!this.webBrowser.IsDisposed && 
             this.webBrowser.Document != null &&
             this.webBrowser.Document.ActiveElement != null)
        {
            this.webBrowser.Document.ActiveElement.Focus();
        }
    }
