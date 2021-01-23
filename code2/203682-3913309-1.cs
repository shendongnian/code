    // another thread
    protected void Loging(){
     while(true){
      while(myQ.Count > 0){
       var content = myQ.Dequeue();
       // save content
      }
      System.Threading.Thread.Sleep(1000);
     }
    }
