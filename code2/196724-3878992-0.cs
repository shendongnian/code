    public class StaticIE : IDisposable
    {
        private IE _ie;
        private int _ieThread;
        private string _ieHwnd;
        private int _processId;
    
        public StaticIE(IE aBrowser)
        {
            SetBrowser(aBrowser);
        }
    
        public IE Browser
        {
            get
            {
                var currentThreadId = GetCurrentThreadId();
                _ie = Browser.AttachTo<IE>(Find.By("hwnd", _ieHwnd), 1);
                if (currentThreadId != _ieThread)
                {
                    _ieThread = currentThreadId;
                }
                return _ie;
            }
        }
    
        private void SetBrowser(IE aBrowser)
        {
            _ie = aBrowser;
            _ieHwnd = _ie.hWnd.ToString();
            _ieThread = GetCurrentThreadId();
            _processId = _ie.ProcessID;
        }
    
        private int GetCurrentThreadId()
        {
            return Thread.CurrentThread.GetHashCode();
        }
    
        public void Dispose()
        {
            if (_ie != null)
            {
                Process.GetProcessById(_processId).Kill();
                _ie = null;
            }
        }
    }
