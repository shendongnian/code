    dynamic d = "test";  
    Console.WriteLine(d.GetType());  
    // Prints "System.String".  
    d = 100;  
    Console.WriteLine(d.GetType());  
    // Prints "System.Int32".    
    dynamic d = "test";  
    // The following line throws an exception at run time.  
    d++;  
