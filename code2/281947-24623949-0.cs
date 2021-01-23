    progBar.Minimum = 0;
    progBar.Maximum = theMaxValue;
    progBar.Value = 0;
    
    Dispatcher disp = Dispatcher.CurrentDispatcher;
    
    new Thread(() => {
        // Code executing in other thread
        while (progBar.Value < theMaxValue)
        {
            // Your application logic here
    
    
            // Invoke Main Thread UI updates
            disp.Invoke(
                () =>
                {
                                
                    progBar.Value++;
                }
            );
    
        }
    }).Start();
