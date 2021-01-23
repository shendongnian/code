    public class CheckComboBox : ComboBox
    {
    	Timer _timer = new Timer();
    
    	public CheckComboBox()
    	{
    		_timer.Interval = 1;
    		_timer.Tick += timer_Tick;		
    	}
    	protected override void OnDropDownClosed(EventArgs e)
    	{
    		base.OnDropDownClosed(e);
    		if (checkbox has been clicked) {
    		    _timer.Start();
    		}
    	}
    
    	void timer_Tick(object sender, EventArgs e)
    	{
    		_timer.Stop();
    		DroppedDown = true; // Reopens dropdown.
    	}
    }
