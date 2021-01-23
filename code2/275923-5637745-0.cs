    private static object lockObj = new object();
    void SomeOperationA()
    {
        lock(lockObj)
        {   
            // Segment1: 
            // ... only executes if no threads are executing in Segment2 ... 
        }    
    }
    void SomeOperationB()
    {
        lock(lockObj)
        { 
            // Segment2: 
            // ... only executes if no threads are executing in Segment1 ... 
        }     
    }
