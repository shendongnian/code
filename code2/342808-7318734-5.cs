    public class WaitForFileSizes
    {
        private readonly object _syncObj = new object();
        private readonly HashSet<string> _seenDirectories = new HashSet<string>();
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
            GetDirectoryFileSizesRecursively(new DirectoryInfo("C:\\temp"));
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
            Parallel.ForEach(dir.EnumerateDirectories(), d =>
            {
                if (!IsSeen(d))
                {
                    GetDirectoryFileSizesRecursively(d);
                }
            });
        }
        private bool IsSeen(DirectoryInfo dir)
        {
            lock (_syncObj)
            {
                if (!_seenDirectories.Contains(dir.FullName))
                {
                    _seenDirectories.Add(dir.FullName);
                    return false;
                }
                return true;
            }
        }
    }
