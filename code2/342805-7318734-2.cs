    internal class WaitForFileSizes
    {
        private readonly AutoResetEvent _pEvent = new AutoResetEvent(false);
        private long _totalFileSize;
        private Thread _thread;
        private volatile bool _abort;
        private void UpdateSize()
        {
            _thread = new Thread(GetDirectoryFileSize);
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
        private void GetDirectoryFileSize()
        {
            GetDirectoryFileSizesRecursively(new DirectoryInfo("C:\\SomeDir"));
            _pEvent.Set();
        }
        private void GetDirectoryFileSizesRecursively(DirectoryInfo dir)
        {
            long directoryFileSize = 0;
            foreach (FileInfo file in dir.EnumerateFiles())
            {
                if (_abort)
                {
                    _pEvent.Set();
                    return;
                }
                directoryFileSize += file.Length;
            }
            Interlocked.Add(ref _totalFileSize, directoryFileSize);
            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                GetDirectoryFileSizesRecursively(subDir);
            }
        }
    }
