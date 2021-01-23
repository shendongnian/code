    static void CopyFileExactly(string copyFromPath, string copyToPath)
        {
            var origin = new FileInfo(copyFromPath);
            
            origin.CopyTo(copyToPath, true);
            var destination = new FileInfo(copyToPath);
            destination.CreationTime = origin.CreationTime;
            destination.LastWriteTime = origin.LastWriteTime;
            destination.LastAccessTime = origin.LastAccessTime;
        }
