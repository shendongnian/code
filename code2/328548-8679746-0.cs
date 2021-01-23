    public void EnableTimer(bool state)
    {
    	if (this.InvokeRequired) {
    		this.Invoke(new Action<bool>(EnableTimer), state);
    	} else {
    		this.Timer1.Enabled = state;
    	}
    }
