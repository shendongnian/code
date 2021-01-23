    public class WaitForFileSizes
    {
        private readonly object _syncObj = new object();
        private readonly HashSet<string> _seenDirectories = new HashSet<string>();
        private long _t;
        public void UpdateSize()
        {
            GetSize(new DirectoryInfo("C:\\temp"));
            Console.WriteLine("Total size {0}b.", _t);
        }
        private void GetSize(DirectoryInfo dir)
        {
            Parallel
            .ForEach(dir.EnumerateFiles(), f => Interlocked.Add(ref _t, f.Length));
            Parallel
            .ForEach(dir.EnumerateDirectories().Where(d => !IsSeen(d)), GetSize);
        }
        private bool IsSeen(FileSystemInfo dir)
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
