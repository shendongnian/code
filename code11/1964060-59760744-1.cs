    private void DoTheTaskAndUpdateGUI(List<string> filesToProcess)
    {
    	var guiDispatcher = Dispatcher.CurrentDispatcher;
    		Task.Factory.StartNew(()=> 
    		{
    			int completionPct = 0;
    			for(int idx = 0;idx<filesToProcess.Count; idx++)
    			{
    				ProcessFile(filesToProcess[idx]);
    				completionPct = ((idx + 1)/filesToProcess.Count) * 100;
    				guiDispatcher.Invoke(UpdateGUI(completionPct));
    			}
    		});
    }
