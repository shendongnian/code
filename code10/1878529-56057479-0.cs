    public class MyJockeys: List<LoadedJockey>
    {
    
        System.Threading.ReaderWriterLock _rw_lock = new System.Threading.ReaderWriterLock();
    
        public new Add(LoadedJockey j)
        {
           try
           {
               _rw_lock.AcquireWriterLock(5000); // or whatever you deem an acceptable timeout
              base.Add(j);
           }
           finally
           {
               _rw_lock.ReleaseWriterLock();
           }
        }
    
        public ToJSON()
        {
           try
           {
               _rw_lock.AcquireReaderLock(5000); // or whatever you deem an acceptable timeout
              string s = "";  // Serialize here using Newtonsoft
              return s;
           }
           finally
           {
               _rw_lock.ReleaseReaderLock();
           }
        }
        // And override Remove and anything else you need
    }
