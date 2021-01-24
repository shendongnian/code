    public interface IDownloadPath
    {
        string Get(); 
    }
    public class DownloadPath_Android : IDownloadPath
    {
        public string Get()
        {
            return Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, Android.OS.Environment.DirectoryDownloads);
        }
    }
