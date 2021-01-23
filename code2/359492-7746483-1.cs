	public void Init()
	{
		myWebBrowser.DocumentCompleted +=  new WebBrowserDocumentCompletedEventHandler(NavigationCompleted);
	}
	public void Navigate()
	{
		myWebBrowser.Navigate(parameter[index++]);
	}
	private void NavigationCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
	{
		 //Do what you have to do with the document loaded in the browser
		 //...
		 //Submit your edit form (click save button)
		 //...
		 Navigate(); //Next!
	}
