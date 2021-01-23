    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
    	var context = SynchronizationContext.Current;
    	Task.Run(() =>
    	{
    		var i = 0;
    		while (true)
    		{
    			context.Post(new SendOrPostCallback((dynamic o) =>
    			{
    				uiText.Text = $"{o.i}";
    			}), new {
    				i = i //pass variables to post
    			});
    
    			Thread.Sleep(1000);
    			i++;
    
    		}
    	});
    
    }
