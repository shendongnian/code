    DateTime start = new DateTime(2011, 3, 3, 0, 0, 0);
    DateTime earlyEnd = new DateTime(2011, 3, 3, 23, 59, 59);
    Console.WriteLine((earlyEnd - start).TotalSeconds); // prints 86399
    
    DateTime lateEnd = new DateTime(2011, 3, 4, 0, 0, 0);
    Console.WriteLine((lateEnd - start).TotalSeconds); // prints 86400
