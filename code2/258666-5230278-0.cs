    // Event object to wait for
    System.Threading.ManualResetEvent _manualEvent = new ManualResetEvent(false);
    private void DisplayMail() {
    	...
    	// register an eventhandler for the close event
    	_newMail.OnClose += new Redemption.IRDOMailEvents_OnCloseEventHandler(_newMail_OnClose);
    	_newMail.Recipients.Add(txtTo);
    	_newMail.Recipients.ResolveAll();
    	_newMail.Subject = subject;
    	_newMail.HTMLBody = body;
    
    	_newMail.Display(false, null);
    	// wait here until the message-window is closed...
    	_manualEvent.WaitOne();
    }
    private void _newMail_OnClose()
    {
    	_manualEvent.Set();
    }
