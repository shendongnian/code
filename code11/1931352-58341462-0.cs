    class WebBrowser
    {
        public event EventHandler DocumentCompleted;
        public async Task RaiseEvent(object o,EventArgs e )
        {
             DocumentCompleted(o, e);
        }
    }
