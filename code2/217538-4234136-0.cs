         private static Dictionary<string, int> foo = new Dictionary<string, int>();
         private static ReaderWriterLock rwLock= new ReaderWriterLock();
         static int reads = 0;
         static int writes = 0;
         
         private static bool Contains(string bar) 
         {
              try 
              { 
                  rwLock.AquireReaderLock(TimeOut.Infinite);
                  InterLocked.Increment(ref reads);
                  return foo.ContainsKey(bar);
              }
              catch(Exception) 
              {
             
              }
              finally 
              {
                    rwLock.ReleaseReaderLock();
              }
         }
         
         public static void Add(string bar)
         {
            try 
            {
               rwLock.AquireWriterLock(TimeOut.Infinite);
                
               if (!ContainsKey(bar)) 
               {
                     foo.Add(bar, 0);
               }
               foo[bar] = foo[bar] + 1;
               Interlocked.Increment(ref writes);
            }
            catch(Exception) {}
            finally 
            {
                  rwLock.ReleaseWriterLock();
            }
