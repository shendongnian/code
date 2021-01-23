    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.IO;
    using System.Runtime.CompilerServices;
    
    namespace ConsoleApplication1
    {
        public class KeyGenerator
        {
            private string FileName;
            private long IncrementedBy;
            private long NextId;
            private long MaxId; 
    
            public KeyGenerator(string filename, long incrementedby)
            {
                FileName = filename;
                IncrementedBy = incrementedby;
                NextId = MaxId = 0; 
            }
    
    
            //[MethodImpl(MethodImplOptions.Synchronized)]
            public long NextID()
            {
    
    
                if (NextId == MaxId)
                {
                    reserveIds();
                }
    
                return NextId++; 
    
            }
    
            private void reserveIds()
            {
    
                Mutex m = new Mutex(false, "Mutex " + FileName.Replace(Path.DirectorySeparatorChar, '_'));
                try
                {
                    m.WaitOne();
                    string s = File.ReadAllText(FileName);
                    long newNextId = long.Parse(s);
                    long newMaxId = newNextId + IncrementedBy; 
                    File.WriteAllText(FileName, newMaxId.ToString());
                    NextId = newNextId;
                    MaxId = newMaxId;
                    // Simulate some work.
                    Thread.Sleep(500);
    
                }
                finally
                {
                    m.ReleaseMutex();
                }
            }
    
        }
    
    }
