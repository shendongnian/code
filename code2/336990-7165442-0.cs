    static void CopyFileExactly(string copyFromPath, string copyToPath)
        {
            var origin = new FileInfo(copyFromPath);
            var destination = new FileInfo(copyToPath);
            origin.CopyTo(destination.FullName, true);
            destination.CreationTime = origin.CreationTime;
            destination.LastWriteTime = origin.LastWriteTime;
            destination.LastAccessTime = origin.LastAccessTime;
        }
