    static void Main(string[] args)
    {
    	MethodToRun();
    }
    
    private static async void MethodToRun()
    {
    	var windowToOpen = new TestForm();
    	var stringValue = String.Empty;
    	Task.Run(new Action(() =>
    	{
    		Dispatcher.CurrentDispatcher.InvokeAsync(() =>
    		{
    			windowToOpen.Show();
    		}).Wait();
    		System.Threading.Thread.Sleep(5000);
    		stringValue = "Plop";
    		Dispatcher.CurrentDispatcher.InvokeAsync(() =>
    		{
    			if (String.Equals(stringValue, "Plop"))
    			{
    				windowToOpen.Close();
    			}
    		}).Wait();
    	})).Wait();
    }
