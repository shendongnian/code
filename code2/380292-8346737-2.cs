	protected static Manager _manager = null;
        protected static Manager _manager = null;
        protected Browser _main;
        protected Find _find;
	public WebAiiAutomater() 
	{
		if (_manager != null)
		{
			foreach (var broswer in _manager.Browsers)
			{
				broswer.Close();
			}
			return;
		}
		var settings = new Settings(BrowserType.InternetExplorer, @"c:\log\") { ClientReadyTimeout = 60 * 1000 };
		_manager = new Manager(settings);
		_manager.Start();
		_manager.LaunchNewBrowser();
        _manager.ActiveBrowser.AutoWaitUntilReady = true;
        _main = _manager.ActiveBrowser;
        _find = _main.Find;
	}
	
	public bool ClickImage(int x, int y)
	{
		//var beginsearch = _find.ById("captcha_img"); //this should get you the image, but you don't need
		_manager.Desktop.Mouse.Click(MouseClickType.LeftClick, x, y);
		Thread.sleep(1000); //wait for postback - might be handled internally though
		var errordiv = _find.ById("error");
		
		return errordiv !=null;
	}
