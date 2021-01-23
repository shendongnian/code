        static bool CanCreateFile(FileInfo fileInfo)
        {
            if (fileInfo.Exists) return false;
            return !fileInfo.Attributes.HasFlag(FileAttributes.ReadOnly);
        }
        static bool CanCreateFile2(FileInfo fileInfo)
        {
            if (fileInfo.Exists) return false;
            return IsDirectoryWriteable(
                Path.GetDirectoryName(fileInfo.FullName));
        }
        static bool IsDirectoryWriteable(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                return IsDirectoryWriteable(directoryInfo.Parent.FullName);
            }
            return !directoryInfo.Attributes.HasFlag(FileAttributes.ReadOnly);
        }
