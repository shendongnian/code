            ThreadStart th = new ThreadStart(CheckValue);
            System.Threading.Thread th1 = new Thread(th);
             
           if(taskStatusComleted)
          { 
            if (th1.IsAlive)
            {
                th1.Abort();
            }
          }
