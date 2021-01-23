    User Control
    
    	public event EventHandler StatusUpdated;
    	private void FunctionThatRaisesEvent()
    	{
            //Null check makes sure the main page is attached to the event
            if (this.StatusUpdated != null)
               this.StatusUpdated(new object(), new EventArgs());
    	}
    
    
    
    Main Page/Form
	public void MyApp()
	{
		//USERCONTROL = your control with the StatusUpdated event
		this.USERCONTROL.StatusUpdated += new EventHandler(MyEventHandlerFunction_StatusUpdated);
	}
    public void MyEventHandlerFunction_StatusUpdated(object sender, EventArgs e)
    {
	     //your code here
    }
