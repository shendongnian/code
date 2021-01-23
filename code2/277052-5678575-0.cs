        static void LoadPipelinedImages(IEnumerable<string> fileNames, 
                                        string sourceDir, 
                                        BlockingCollection<ImageInfo> original,
                                        CancellationTokenSource cts)
        {
            // ...
            var token = cts.Token;
            ImageInfo info = null;
            try
            {
                foreach (var fileName in fileNames)
                {
                    if (token.IsCancellationRequested)
                        break;
                    info = LoadImage(fileName, ...);
                    original.Add(info, token);
                    info = null;
                }                
            }
            catch (Exception e)
            {
                // in case of exception, signal shutdown to other pipeline tasks
                cts.Cancel();
                if (!(e is OperationCanceledException))
                    throw;
            }
            finally
            {
                original.CompleteAdding();
                if (info != null) info.Dispose();
            }
        }
