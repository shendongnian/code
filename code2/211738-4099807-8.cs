    public class LongOp
    {
        //The delegate
        Action longOpDelegate = LongOp.DoLongOp;
        //The result
        public string longOpResult = null;
    
        // Declare a manual reset at module level so it can be 
        // handled from both your callback and your called method
        ManualResetEvent waiter;
    
        //The Main Method
        public string CallLongOp()
        {
            // Set a manual reset which you can reset within your callback
            waiter = new ManualResetEvent(false);
            //Call the asynchronous operation
            IAsyncResult result = longOpDelegate.BeginInvoke(Callback, null);    
            // Wait
            waiter.WaitOne();
    
            //return result saved in Callback
            return longOpResult;
        }
    
        //The long operation
        static void DoLongOp()
        {
            Thread.Sleep(5000);
        }
    
        //The Callback
        void Callback(IAsyncResult result)
        {
            longOpResult = "Completed";
            this.longOpDelegate.EndInvoke(result);
                    
            waiter.Set();
        }
    }
