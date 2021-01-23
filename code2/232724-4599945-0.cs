    class MyClass
    {
    	private Dispatcher dispatcher;
    	public void runThirdParty()
    	{
    		this.dispatcher = Dispatcher.CurrentDispatcher;
    		callThirdPartyFunction(myCallBack);
    	}
    
    	public void myCallBack()
    	{
    		this.dispatcher.Invoke(new Action(() =>
    		{
    			//code to run here.
    		}));
        }
     }
