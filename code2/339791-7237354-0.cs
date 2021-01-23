    private object DoWork(string[] fileList, ProgressDialogViewModel viewModel)
    {
        int done; // For proper synchronization
        Parallel.ForEach(fileList, 
           imagePath => 
           {
               ProcessImage(imagePath));
               Interlocked.Increment(ref done);
               viewModel.Progress = done;
           }
    }
