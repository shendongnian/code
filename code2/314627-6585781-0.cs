    Thread b = new Thread(new ThreadStart()({ delegate()
    {
       int t=0;
       while(i<100)
       { 
    
           if( File.Exists(stopFile) )
           {
               a.Abort();
              
            }
            else
            {
               i++;
               Thread.Sleep(500);
            }
        }
    
    }));
