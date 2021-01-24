    public YourClass()
    {
    	InitializeComponent();
    	//const int id = 0; // The id of the hotkey.
    	// For eaxple hot key F5
    	RegisterHotKey(Handle, 0, (int)KeyModifier.None, Keys.F5.GetHashCode());
    }
    protected override void WndProc(ref Message message)
    {
    	base.WndProc(ref message);
    	if (message.Msg == 0x0312)
    	{
    		var id = message.WParam.ToInt32();
    		if (id == 0)
    		{
    			/*
    			 * Write a method hee what you want to do.
    			*/
    			// Let the command press the right arraybotton instead.
    			SendKeys.SendWait("{RIGHT}");
    		}
    	}
    }
