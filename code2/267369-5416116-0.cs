    void Main(string[] args)
    {
    	var auBackend = new AutomaticUpdaterBackend
    	{
    		GUID = "CeALauncher_AutoUpdate",
    		UpdateType = UpdateType.Automatic,
    	};
    
    	var checkingFailed = Observable.FromEvent<FailArgs>(h => auBackend.CheckingFailed += h, h => auBackend.CheckingFailed -= h);
    	var updateAvailable = Observable.FromEvent<EventArgs>(h => auBackend.UpdateAvailable += h, h => auBackend.UpdateAvailable -= h);
    	var downloadingFailed = Observable.FromEvent<FailArgs>(h => auBackend.DownloadingFailed += h, h => auBackend.DownloadingFailed -= h);
    	var extractingFailed = Observable.FromEvent<FailArgs>(h => auBackend.ExtractingFailed += h, h => auBackend.ExtractingFailed -= h);
    	var readyToBeInstalled = Observable.FromEvent<EventArgs>(h => auBackend.ReadyToBeInstalled += h, h => auBackend.ReadyToBeInstalled -= h);
    	var updateSuccessful = Observable.FromEvent<SuccessArgs>(h => auBackend.UpdateSuccessful += h, h => auBackend.UpdateSuccessful -= h);
    	var updateFailed = Observable.FromEvent<FailArgs>(h => auBackend.UpdateFailed += h, h => auBackend.UpdateFailed -= h);
    
    	var readyToBeInstalledStepReady = readyToBeInstalled.Where(e => auBackend.UpdateStepOn == UpdateStepOn.UpdateReadyToInstall);
    	var readyToBeInstalledStepNotReady = readyToBeInstalled.Where(e => auBackend.UpdateStepOn != UpdateStepOn.UpdateReadyToInstall);
    	
    	var failed = Observable.Merge(new []
    	{
    		checkingFailed.Select(e => "Checking Failed"),
    		downloadingFailed.Select(e => "Downloading Failed"),
    		extractingFailed.Select(e => "Extracting Failed"),
    		updateFailed.Select(e => "Update Failed"),
    		readyToBeInstalledStepNotReady.Select(e => "Update Not Ready"),
    	});
    	
    	var success = Observable.Merge(new []
    	{
    		readyToBeInstalledStepReady.Select(e => "Update Ready"),
    		updateSuccessful.Select(e => "Update Successful"),
    	});;
    	
    	failed.Subscribe(e => Console.Error.WriteLine(e));
    	success.Subscribe(e => Console.WriteLine(e));
    	
    	readyToBeInstalledStepReady.Subscribe(e => auBackend.InstallNow());
    
    	auBackend.Initialize();
    	auBackend.AppLoaded();
    
    	if (!auBackend.ClosingForInstall)
    	{
    		if (auBackend.UpdateStepOn == UpdateStepOn.Nothing)
    		{
    			auBackend.ForceCheckForUpdate();
    		}
    	}            
    
    	success.Merge(failed).First();
    }
