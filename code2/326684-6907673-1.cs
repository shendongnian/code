    Thread t = new Thread(Quote);
    t.Start();
    private List<Work> workList = new List<Work>(); // Shared across the threads, they should belong to the same class, otherwise you've to make it public member
    private void Quote()
    { 
         lock(workList) // Get a lock on this resource so other threads can't access it until my operation is finished
         {
             foreach (Work w in works)
             {
               // do something on the workList items
             }
         }
    }
