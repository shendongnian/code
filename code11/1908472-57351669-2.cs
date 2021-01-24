    class DownloadService {
        public void DownloadData(IProgress<int> progress = null) {            
            int totalDownloaded = 0;
            for (int i = 0; i < 101; i++) {
                totalDownloaded++;
                progress?.Report(totalDownloaded); // ?. just in case
                Console.WriteLine(totalDownloaded);
            }
        }
    }
