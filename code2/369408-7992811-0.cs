    class Job : AppointmentBase
    {
    	public override DateTime End
    	{
    		get { return base.End; }
    		set
    		{
    			MessageBox.Show("Unbelievable!");
    			base.End = value;
    		}
    	}
    }
