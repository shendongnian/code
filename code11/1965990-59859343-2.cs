    public static void FileShareByteCount(CloudFileDirectory directory, int? maxResults, ref long bytesCount)
    {
        FileContinuationToken continuationToken = null;
        do
        {
            var resultSegment = directory.ListFilesAndDirectoriesSegmented(maxResults, continuationToken, null, null);
            if (resultSegment.Results.Count() > 0)
            {
                foreach (var item in resultSegment.Results)
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
        } while (continuationToken != null);
    }
