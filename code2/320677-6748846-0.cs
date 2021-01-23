            delegate void SetProgressBarCallback();
    
    		private void SetProgressBar()
    		{
    			// InvokeRequired required compares the thread ID of the
    			// calling thread to the thread ID of the creating thread.
    			// If these threads are different, it returns true.
    			if (this.progressBar1.InvokeRequired)
    			{	
    				SetProgressBarCallback d = new SettProgressBarCallback(SetProgressBar);
    				this.Invoke(d);			
                }
    			else
    			{
    				for(int i=0; i<99; i++)
                    {
                         Thread.Sleep(1);
                         progressBar1.Value = i;
                     }
    			}
    		}
