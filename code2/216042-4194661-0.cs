    const int MaxRetries = 5;
    
    for(int i = 0; i < MaxRetries; i++)
    {
       try
       {
           // do stuff
    
           break; // jump out of for loop if everything succeeded
       }
       catch(Exception)
       {
           Thread.Sleep(100); // optional delay here
       }
    }
