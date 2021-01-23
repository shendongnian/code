    internal class WaitForFileSizes
    {
        private readonly AutoResetEvent _pEvent = new AutoResetEvent(false);
        private long _totalFileSize;
        private Thread _thread;
        private volatile bool _abort;
        private void UpdateSize()
        {
            _thread = new Thread(GetFolderFileSizes);
            _thread.Start();
            bool timedout = !_pEvent.WaitOne(5000);
            if (timedout)
            {
                _abort = true;
                _pEvent.WaitOne();
                Console.WriteLine("A thread timed out.");
            }
            else
            {
                Console.WriteLine("Total size {0}b.", _totalFileSize);
            }
        }
        private void GetFolderFileSizes()
        {
            long bytesSzNew = 0;
            DirectoryInfo di = new DirectoryInfo("C:\\SomeDir");
            DirectoryInfo[] directories = di.GetDirectories(SearchOption.AllDirectories);
            FileInfo[] files = di.GetFiles(SearchOption.AllDirectories);
            foreach (FileInfo file in files)
            {
                if (_abort)
                {
                    _pEvent.Set();
                    return;
                }
                if (!fileSizes.TryGetValue(file.Name, out lastSize))
                {
                    fileSizes.Add(file.Name, file.Length);
                    bytesSzNew += file.Length;
                }
            }
            Thread.VolatileWrite(ref _totalFileSize, bytesSzNew);
            _pEvent.Set();
        }
    }
