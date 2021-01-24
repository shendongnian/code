    private void StartScan_Click(object sender, RoutedEventArgs e)
    {
    	// This is the button
    	var btn = sender as Button;
    
    	// Now we get the template that the button is in.
    	var contentPresenter = (btn.TemplatedParent as ContentPresenter);
    	
    	// Finally we find the progress by its name in the template. Also we have to pass the content
    	// presenter as the second argument since this is where the actual instance of the control is.
    	var progress = contentPresenter.ContentTemplate.FindName("pbStatus", contentPresenter) as ProgressBar;
    
    	// Do your logic normally as you would.
    	progress.IsIndeterminate = !progress.IsIndeterminate;
    	btn.Content = progress.IsIndeterminate ? "Stop" : "Start";
    }
