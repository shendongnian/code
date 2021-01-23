    var refs = GetReferencesFromDB();
    // Using Parallel::ForEach here will partition and process your data on separate worker threads
    Parallel.ForEach(ref =>
    { 
        string filePath = GetFilePath(ref);
        byte[] fileDataBuffer = new byte[1048576];
        // Need to use FileStream API directly so we can enable async I/O
        FileStream sourceFileStream = new FileStream(
                                          filePath, 
                                          FileMode.Open,
                                          FileAccess.Read,
                                          FileShare.Read,
                                          8192,
                                          true);
        // Use FromAsync to read the data from the file
        Task<int> readSourceFileStreamTask = Task.Factory.FromAsync(
                                                 sourceFileStream.BeginRead
                                                 sourceFileStream.EndRead
                                                 fileDataBuffer,
                                                 fileDataBuffer.Length,
                                                 null);
        // Add a continuation that will fire when the async read is completed
        readSourceFileStreamTask.ContinueWith(readSourceFileStreamAntecedent =>
        {
            int soureFileStreamBytesRead;
            try
            {
                // Determine exactly how many bytes were read 
                // NOTE: this will propagate any potential exception that may have occurred in EndRead
                sourceFileStreamBytesRead = readSourceFileStreamAntecedent.Result;
            }
            finally
            {
                // Always clean up the source stream
                sourceFileStream.Close();
                sourceFileStream = null;
            }
            // This is here to make sure you don't end up trying to read files larger than this sample code can handle
            if(sourceFileStreamBytesRead == fileDataBuffer.Length)
            {
                throw new NotSupportedException("You need to implement reading files larger than 1MB. :P");
            }
            // Convert the file data to a string
            string html = Encoding.UTF8.GetString(fileDataBuffer, 0, sourceFileStreamBytesRead);
            // Parse the HTML
            string convertedHtml = ParseHtml(html);
            // This is here to make sure you don't end up trying to write files larger than this sample code can handle
            if(Encoding.UTF8.GetByteCount > fileDataBuffer.Length)
            {
                throw new NotSupportedException("You need to implement writing files larger than 1MB. :P");
            }
            // Convert the file data back to bytes for writing
            Encoding.UTF8.GetBytes(convertedHtml, 0, convertedHtml.Length, fileDataBuffer, 0);
            
            // Need to use FileStream API directly so we can enable async I/O
            FileStream destinationFileStream = new FileStream(
                                                   destinationFilePath,
                                                   FileMode.OpenOrCreate,
                                                   FileAccess.Write,
                                                   FileShare.None,
                                                   8192,
                                                   true);
            // Use FromAsync to read the data from the file
            Task destinationFileStreamWriteTask = Task.Factory.FromAsync(
                                                      destinationFileStream.BeginWrite,
                                                      destinationFileStream.EndWrite,
                                                      fileDataBuffer,
                                                      0,
                                                      fileDataBuffer.Length,
                                                      null);
            // Add a continuation that will fire when the async write is completed
            destinationFileStreamWriteTask.ContinueWith(destinationFileStreamWriteAntecedent =>
            {
                try
                {
                    // NOTE: we call wait here to observe any potential exceptions that might have occurred in EndWrite
                    destinationFileStreamWriteAntecedent.Wait();
                }
                finally
                {
                    // Always close the destination file stream
                    destinationFileStream.Close();
                    destinationFileStream = null;
                }
            },
            TaskContinuationOptions.AttachedToParent);
            // Send to external system **concurrent** to writing to destination file system above
            SendToWs(ref, convertedHtml);
        },
        TaskContinuationOptions.AttachedToParent);
    });
