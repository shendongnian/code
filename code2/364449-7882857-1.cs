	List<Uri> HistoryStack;
	int HistoryStack_Index;
	bool fromHistory;
	// Constructor
	public HelpView()
	{
		InitializeComponent();
		HistoryStack = new List<Uri>();
		HistoryStack_Index = 0;
		fromHistory = false;
		webView.Navigated += new EventHandler<System.Windows.Navigation.NavigationEventArgs>(WebView_Navigated);
		UpdateNavButtons();
	}
	private void backButton_Click(object sender, RoutedEventArgs e)
	{
		if (HistoryStack_Index > 1)
		{
			HistoryStack_Index--;
			fromHistory = true;
			webView.Navigate(HistoryStack[HistoryStack_Index-1]);
			updateNavButtons();
		}
	}
	private void forwardButton_Click(object sender, RoutedEventArgs e)
	{
		if (HistoryStack_Index < HistoryStack.Count)
		{
			HistoryStack_Index++;
			fromHistory = true;
			webView.Navigate(HistoryStack[HistoryStack_Index-1]);
			UpdateNavButtons();
		}
	}
	private void UpdateNavButtons()
	{
		this.backButton.IsEnabled = HistoryStack_Index > 1;
		this.forwardButton.IsEnabled = HistoryStack_Index < HistoryStack.Count;
	}
	private void WebView_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
	{
		if (!fromHistory)
		{
			if (HistoryStack_Index < HistoryStack.Count)
			{
				HistoryStack.RemoveRange(HistoryStack_Index, HistoryStack.Count - HistoryStack_Index);
			}
			
			HistoryStack.Add(e.Uri);
			HistoryStack_Index++;
			UpdateNavButtons();
		}
		
		fromHistory = false;
	}
