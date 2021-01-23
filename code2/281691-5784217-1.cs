     // create a document queue
        private static Queue<string> docQueue = new Queue<string>();
        // create async caller and result handler
        IAsyncResult docAdded = null;
        public delegate bool AsyncMethodCaller(string doc);
        // 
        public void Start()
        {
            // create a dummy doc
            string doc = "test";
            // start the async method
            AsyncMethodCaller runfirstCaller = new AsyncMethodCaller(DoWork);
            docAdded = runfirstCaller.BeginInvoke(doc,null,null);
            docAdded.AsyncWaitHandle.WaitOne();
            // get the result
            bool b = runfirstCaller.EndInvoke(docAdded);
        }
        // add the document to the queue
        bool DoWork(string doc)
        {
            
            lock (docQueue)
            {
                if (docQueue.Contains(doc))
                {
                    return false;
                }
                else
                {
                    docQueue.Enqueue(doc);
                    return true;
                }
            }
        }
    }
