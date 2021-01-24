    public class FileProcessor
    {
        private const long TotalSizeMax = 1073741824; // 1 GB
        private static long _totalSizeCurrent;
    
        public void ProcFiles(IList<FileInfo> fiList)
        {
            var totalFiles = fiList.Count;
            var index = 0;
            var fi = fiList[index];
            while (totalFiles > index)
            {
                Monitor.Enter(_totalSizeCurrent);
                var totalCandidate = _totalSizeCurrent + fi.Length;
                if (totalCandidate > TotalSizeMax)
                {
                    Monitor.Exit(_totalSizeCurrent);
                    Task.Delay(2000).Wait(); // delay 2 seconds
                    continue;
                }
                _totalSizeCurrent = totalCandidate;
                Monitor.Exit(_totalSizeCurrent);
                Task.Run(() =>
                {
                    // Start parse FileInfo fi
                    //...
    
                    // End parse
                    Monitor.Enter(_totalSizeCurrent);
                    _totalSizeCurrent -= fi.Length;
                    Monitor.Exit(_totalSizeCurrent);
                });
    
                index++;
            }
        }
    }
