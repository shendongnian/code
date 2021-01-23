    public class PageWatcher
    {
        private int mindex;
        private string murl;
        private string mname;
        private int mtimer;
        bool IsRunning = true;
        public event EventHandler<ConnectionAttemptEventArgs> ConnectionAttempt;
        // The constructor obtains the state information.
        public PageWatcher(int index, string url, string name, int timer)
        {
            mindex = index;
            murl = url;
            mname = name;
            mtimer = timer;
        }
        public void StartProcess()
        {
            //First run checking
            string lastResult = "Connection Success";
            
            while (IsRunning)
            {
                Thread.Sleep(mtimer);
                IsRunning = false;
                try
                {
                    //FileManager.WriteActivityLog("Process Start", mname);
                    DateTime start = DateTime.Now;
                    string html = Utility.RequestWebpage(murl, string.Empty, true);
                    TimeSpan minisecond = DateTime.Now - start;
                    FileManager.WriteActivityLog("time:" + minisecond.Milliseconds.ToString() + ", html length:" + html.Length.ToString(), mname);
                    //FileManager.WriteActivityLog("html:" + html, mname);
                    //FileManager.WriteActivityLog("Process End", mname);
                    lastResult = "Connection Success";
                }
                catch (Exception ex)
                {
                    ExceptionManager.WriteErrorLog(ex.Message, true, mname);
                    lastResult = ex.Message;
                }
                IsRunning = true;
                OnConnectionAttempt(result);
            }
        }
  
        private void OnConnectionAttempt(string result)
        {
            var handler = ConnectionAttempt;
            if (handler != null)
            {
                handler(this, new ConnectionAttemptEventArgs(mindex, result));
            }
        }
    }
    
    public class ConnectionAttemptEventArgs : EventArgs
    {
        public readonly int Index;
        public readonly string Result;
        public ConnectionResultEventArgs (int index, string result)
        {
            Index = index;
            Result = result;
        }
    }
