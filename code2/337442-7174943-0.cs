        public class MyEntity
    {
      public event EventHandler Load_Succeeded;
      public event EventHandler Load_Failed;
      public void Load()
      {
        /*
         Asynchronously load the entity code here.
        */
      }
    
      private void Load_Completed(IAsyncResult result)
      {
        // Fire Load_Succeeded or Load_Failed
      }
      public void ResetEvents()
      {
            this.Load_Succeeded = null;
            this.Load_Failed = null;
      }
    }
