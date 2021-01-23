     int maxCount = 5;
     SemaphoreSlim slim = new SemaphoreSlim(5, maxCount);            
    
     if (slim.CurrentCount == maxCount)
     {
        // generate error
     }
     else
     {
       slim.Release();
     }
