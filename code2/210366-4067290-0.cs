    class MyConnection : IDisposable
    {
       public void Dispose()
       {
          //close the connection and release resources
       }
    }
    using (MyConnection conn = new MyConnection(connStr))
    {
      
    } //automatically Dispose()
