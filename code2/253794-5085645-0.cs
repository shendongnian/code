    Task.Factory.StartNew(() => 
    {
        // print a message when the task is started
        Console.WriteLine("Task started!"); 
        
        var listner = new Listener();
        listner.ProcessEvents(); 
    });
