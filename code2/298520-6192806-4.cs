    public void MyApp()
    {
         //USERCONTROL = your control with the StatusUpdated event
    	 this.USERCONTROL.StatusUpdated += new EventHandler(MyEventHandlerFunction_StatusUpdated);
    }
    
    public void MyEventHandlerFunction_StatusUpdated(object sender, EventArgs e)
    {
    	     //your code here
    }
