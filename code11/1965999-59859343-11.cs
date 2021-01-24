    public static void FileShareByteCount(CloudFileDirectory directory, ref long bytesCount)
    {
        if (directory == null)
        {
            throw new ArgumentNullException("directory", "Directory cannot be null");
        }
        var files = directory.ListFilesAndDirectories();
        foreach (var item in files)
        {
            if (item.GetType() == typeof(CloudFileDirectory))
            {
                var cloudFileDirectory = item as CloudFileDirectory;
                FileShareByteCount(cloudFileDirectory, ref bytesCount);
            }
            else if (item.GetType() == typeof(CloudFile))
            {
                var cloudFile = item as CloudFile;
                bytesCount += cloudFile.Properties.Length;
            }
        }
    }
