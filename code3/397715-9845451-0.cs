     private void InitWatch()
    {
    	FileSystemWatcher watcher = new FileSystemWatcher();
    	watcher.Path = @"C:\LoQueSea";
    	watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
    	| NotifyFilters.FileName | NotifyFilters.DirectoryName;
    	watcher.Filter = "*.*";
    	watcher.Created += new FileSystemEventHandler(OnCreated);
    	watcher.EnableRaisingEvents = true;
    }
     private void OnCreated()
    {
    	try
    	{
    		if (!myObjectToPrint.Dispatcher.CheckAccess())
    		{
    			myObjectToPrint.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
    				new Action(
    				   delegate()
    				   {
    				    your code here...
    				   }
    				   )
    		}
    	}
    	catch (Exception ex)
    	{
    		throw ex;
    	}          
    }
