    using System.Linq;
    using System.IO;
    DirectoryInfo di = new DirectoryInfo("mylogdir");
    FileSystemInfo[] files = di.GetFileSystemInfos();
    var orderedFiles = files.OrderBy(f => f.CreationTime);
