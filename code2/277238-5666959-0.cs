    TaskFactory myFactory = new TaskFactory();
    
    method1(); // Execute Synchronously
    
    Task t1 = myFactory.StartNew(method2); // Create and start new concurrent task
    Task t2 = myFactory.StartNew(method3); // Create and start new concurrent task
    
    t1.Wait(); // Ensure completion
    t2.Wait(); // Ensure completion
    
    method4(); //Execute Synchronously
