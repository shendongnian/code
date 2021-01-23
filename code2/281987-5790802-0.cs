    var parent = Task.Factory.StartNew(() =>
    {
        Console.WriteLine("Parent task beginning.");
    
        var child = Task.Factory.StartNew(() =>
        {
            Thread.SpinWait(5000000);
            Console.WriteLine("Attached child completed.");
        }, TaskCreationOptions.AttachedToParent);
    
    });
    
    parent.Wait();
    Console.WriteLine("Parent task completed.");
    
    /* Output:
        Parent task beginning.
        Attached task completed.
        Parent task completed.
     */
