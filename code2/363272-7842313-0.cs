    public Task<bool> CoockinRequestAsync()
    {
        var indicator = new ActivityIndicator();
        ActivityIndicator.Show("Oooo coockin' something cool");
        // This assumes Cook() returns bool...
        var task = Task.Factory.StartNew(CockinService.Cook);
        // Handle your removal of the indicator here....
        task.ContinueWith( (t) => 
           {
               indicator.Hide();
           }, TaskScheduler.FromCurrentSynchronizationContext());
        // Return the task so the caller can schedule their own completions
        return task;
    }
