    private static async Task MergeFiles(IEnumerable<string> sourceFilePaths,
        string targetFilePath, CancellationToken cancellationToken = default,
        IProgress<int> progress = null)
    {
        var readerBlock = new TransformBlock<string, string>(async filePath =>
        {
            return File.ReadAllText(filePath); // Read the small file
            //return await File.ReadAllTextAsync(filePath); // .NET Core supports async
        }, new ExecutionDataflowBlockOptions()
        {
            MaxDegreeOfParallelism = 2, // Reading is parallelizable
            BoundedCapacity = 100, // No more than 100 file-paths buffered
            CancellationToken = cancellationToken, // Cancel at any time
        });
        StreamWriter streamWriter = null;
        int filesProcessed = 0;
        var writerBlock = new ActionBlock<string>(async text =>
        {
            await streamWriter.WriteAsync(text); // Append to the target file
            filesProcessed++;
            if (filesProcessed % 10 == 0) progress?.Report(filesProcessed);
        }, new ExecutionDataflowBlockOptions()
        {
            MaxDegreeOfParallelism = 1, // We can't parallelize the writer
            BoundedCapacity = 100, // No more than 100 file-contents buffered
            CancellationToken = cancellationToken, // Cancel at any time
        });
        readerBlock.LinkTo(writerBlock,
            new DataflowLinkOptions() { PropagateCompletion = true });
        // This is a tricky part. We use BoundedCapacity, so we must complete manually
        // the reader in case of a writer failure, otherwise a deadlock may occur.
        OnErrorComplete(writerBlock, readerBlock);
        // Open the output stream
        using (streamWriter = new StreamWriter(targetFilePath))
        {
            // Feed the reader with the file paths
            foreach (var filePath in sourceFilePaths)
            {
                var accepted = await readerBlock.SendAsync(filePath,
                    cancellationToken); // Cancel at any time
                if (!accepted) break; // This will happen if the reader fails
            }
            readerBlock.Complete();
            await writerBlock.Completion;
        }
        async void OnErrorComplete(IDataflowBlock block1, IDataflowBlock block2)
        {
            await Task.WhenAny(block1.Completion); // Safe awaiting
            if (block1.Completion.IsFaulted) block2.Complete();
        }
    }
