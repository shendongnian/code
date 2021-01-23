    public void KeyDownSink(object sender, System.Windows.Input.KeyEventArgs e)  {
    	    var pressedModifiers = e.KeyboardDevice.Modifiers;
    		if (pressedModifiers != ModifierKeys.None) return;
    		
    		//do your stuff
    }
