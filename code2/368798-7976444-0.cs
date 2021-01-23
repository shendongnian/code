    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace AC.ChatServer.Classes
    {
        public delegate void OnDataAddedHandler(string data);
        public class LogManager
        {
            #region Fields
            private System.Threading.Mutex logMutex;
            private string filePath;
            private static LogManager instance;
            private AndcQ q;
            #endregion
    
    
            #region Property
            public void Initiate()
            {
            }
            public static LogManager Instance
            {
                get
                {
                    if (instance == null)
                        instance = new LogManager();
                    return instance;
                }
            }
            #endregion
    
            #region Helper function
            public void AddtOlog(string data)
            {
                q.Enqueue(data);
            }
            #endregion
    
            #region Constructor
            private LogManager()
            {
    
                q = new AndcQ(100);
                filePath = System.Configuration.ConfigurationManager.AppSettings["LogFileFolder"];
                logMutex = new System.Threading.Mutex();
                q.DataAdded += new OnDataAddedHandler(q_DataAdded);
    
            }
            private string GetFileName()
            {
                string fileName = DateTime.Today.ToString("_yyyyMMdd");
                return string.Format(@"{0}\{1}.txt", filePath, fileName);
            }
            private void WriteToFile(object data)
            {
    
                string fileName = GetFileName();
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, true, Encoding.UTF8))
                {
                    sw.WriteLine(data.ToString());
                }
            }
            private delegate void WriteToFileCallBack(string data);
            void q_DataAdded(string data)
            {
                logMutex.WaitOne();
                WriteToFileCallBack caller = new WriteToFileCallBack(WriteToFile);
                IAsyncResult r = caller.BeginInvoke(data, null, null);
                caller.EndInvoke(r);
                logMutex.ReleaseMutex();
            }
            #endregion
        }
        public class AndcQ : System.Collections.Queue
        {
            #region Events
            public event OnDataAddedHandler DataAdded;
            #endregion
    
    
            public AndcQ(int capacity)
                : base(capacity)
            {
    
            }
            public AndcQ()
                : base()
            {
    
            }
            public new void Enqueue(object obj)
            {
    
                base.Enqueue(obj);
                if (DataAdded != null)
                    lock (this)
                    {
                        if (this.Count > 0)
                        {
                            DataAdded(this.Dequeue().ToString());
                        }
                    }
            }
        }
    }
