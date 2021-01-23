    public void Crawl()
    {
       int report = 0;
       while(true)
       {
           if(!(queue.Count == 0))      
           {   
              if(report > 0) Interlocked.Decrement(ref report);
              //dequeue      
              if(token == "TERMINATION")
                 return;     
              else
                 //enqueue child links
           }
           else
           {
              
              if(report == num_threads)
                 queue.Enqueue("TERMINATION");
              else
                 Interlocked.Increment(ref report); // this thread has found the queue empty
           }
        }
    }
