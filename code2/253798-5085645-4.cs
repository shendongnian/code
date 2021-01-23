    Thread listenerThread = new Thread(() => 
    {
        // print a message when the task is started
        Console.WriteLine("Task started!"); 
        
        var listner = new Listener();
        listner.ProcessEvents(); 
    });
    
    // set your thread to background so it doesn't live on
    // even after you're 
    listenerThread.IsBackground = true;
    listenerThread.Start();
