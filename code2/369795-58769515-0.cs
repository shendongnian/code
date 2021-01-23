    using System.Threading.Tasks;
    
    public bool isChanging = false;
    async private void Textbox1_TextChanged(object sender,
    										TextChangedEventArgs e)
    	{
    		// entry flag
    		if (isChanging)
    		{
    			return;
    		}
    		isChanging = true;
    		await Task.Delay(500);
    
    		// do your stuff here or call a function
    
    		// exit flag
    		isChanging = false;
    	}
