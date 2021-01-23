    private void OnFirstTimeLoad()
    {
        Task.Factory.StartNew(() =>
	    {
       	    foreach (var row in ViewModel.Rows)									               
            {
                /*this is all you really need, 
                  note: since you're on the background thread, make sure IsVisible executes on the UI thread, my utils method does just that*/
                  myUtils.ExecuteOnUiThread(() => row.IsVisible = true);
                  /*optional tweak: 
                  this just forces Ui to refresh so each row repaint staggers nicely*/
                  Application.Current.Dispatcher
                             .Invoke(DispatcherPriority.Background, (SendOrPostCallback) delegate { }, null);
		     }
           });
    }
