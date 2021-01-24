    public static void FileShareByteCount(CloudFileDirectory directory, int? maxResults, ref long bytesCount)
    {
        if (directory == null)
        {
            throw new ArgumentNullException("directory", "Directory cannot be null");
        }
        FileContinuationToken continuationToken = null;
        do
        {
            var resultSegment = directory.ListFilesAndDirectoriesSegmented(maxResults, continuationToken, null, null);
            var results = resultSegment.Results;
            if (results.Count() > 0)
            {
                foreach (var item in results)
                {
                    if (item.GetType() == typeof(CloudFileDirectory))
                    {
                        var cloudFileDirectory = item as CloudFileDirectory;
                        FileShareByteCount(cloudFileDirectory, maxResults, ref bytesCount);
                    }
                    else if (item.GetType() == typeof(CloudFile))
                    {
                        var cloudFile = item as CloudFile;
                        bytesCount += cloudFile.Properties.Length;
                    }
                }
            }
            continuationToken = resultSegment.ContinuationToken;
        } while (continuationToken != null);
    }
