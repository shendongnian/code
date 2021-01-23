        static void CopyFileExactly(string copyFromPath, string copyToPath)
        {
            if (File.Exists(copyToPath))
            {
                var target = new FileInfo(copyToPath);
                if (target.IsReadOnly)
                    target.IsReadOnly = false;
            }
            var origin = new FileInfo(copyFromPath);
            origin.CopyTo(copyToPath, true);
            var destination = new FileInfo(copyToPath);
            if (destination.IsReadOnly)
            {
                destination.IsReadOnly = false;
                destination.CreationTime = origin.CreationTime;
                destination.LastWriteTime = origin.LastWriteTime;
                destination.LastAccessTime = origin.LastAccessTime;
                destination.IsReadOnly = true;
            }
        }
