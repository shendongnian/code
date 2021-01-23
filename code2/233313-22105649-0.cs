    Task<int> ShowModalAletViewAsync (string title, string message, params string[] buttons)
    {
        var alertView = new UIAlertView (title, message,  null, null, buttons);
        alertView.Show ();
        var tsc = new TaskCompletionSource<int> ();
        
        alertView.Clicked += (sender, buttonArgs) => {
        	Console.WriteLine ("User clicked on {0}", buttonArgs.ButtonIndex);		
        	tsc.TrySetResult(buttonArgs.ButtonIndex);
        };    
        return tsc.Task;
    }		
