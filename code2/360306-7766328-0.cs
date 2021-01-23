    private void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    	{
    		while(true)
    		{
    			if(worker.CancellationPending)
    			{
    				e.Cancel = true;
    				return;
    			}
    		
    			Thread.Sleep(100);
    		}
    	}
