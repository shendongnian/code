        static void RunPipelined(IEnumerable<string> fileNames, 
                                 string sourceDir, 
                                 int queueLength, 
                                 Action<ImageInfo> displayFn,
                                 CancellationTokenSource cts)
        {
            // Data pipes 
            var originalImages = new BlockingCollection<ImageInfo>(queueLength);
            var thumbnailImages = new BlockingCollection<ImageInfo>(queueLength);
            var filteredImages = new BlockingCollection<ImageInfo>(queueLength);
            try
            {
                var f = new TaskFactory(TaskCreationOptions.LongRunning,
                                        TaskContinuationOptions.None);
                // ...
                // Start pipelined tasks
                var loadTask = f.StartNew(() =>
                      LoadPipelinedImages(fileNames, sourceDir, 
                                          originalImages, cts));
                var scaleTask = f.StartNew(() =>
                      ScalePipelinedImages(originalImages, 
                                           thumbnailImages, cts));
                var filterTask = f.StartNew(() =>
                      FilterPipelinedImages(thumbnailImages, 
                                            filteredImages, cts));
                var displayTask = f.StartNew(() =>
                      DisplayPipelinedImages(filteredImages.GetConsumingEnumerable(), 
                           ... cts));
                Task.WaitAll(loadTask, scaleTask, filterTask, displayTask);
            }
            finally
            {
                // in case of exception or cancellation, there might be bitmaps
                // that need to be disposed.
                DisposeImagesInQueue(originalImages);
                DisposeImagesInQueue(thumbnailImages);
                DisposeImagesInQueue(filteredImages);                
            }
        }
