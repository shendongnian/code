    System.Threading.Timer t = new Timer(myListReadingProc, null, 1000, 1000);
    private void myListReadingProc(object s)
    {
        while(isStarted)
        {
           while (myQueue.Count > 0)
           {
               lock (myQueue)
               {
                   string item = myQueue.Dequeue();
                   // do whatever
               }
           }
        }
    }
