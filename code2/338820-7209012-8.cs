    private void UpdateCountInBackground()
    {
        Task.Factory.StartNew(
            () =>
            {
                int current = 0, allowed = 0;
                Task.WaitAll(
                    Task.Factory.StartNew(() => current = func1()),
                    Task.Factory.StartNew(() => allowed = func2()));                   
                Invoke(new Action(() => 
                    labelCount.Text = "Using " + current.ToString() + " of " + allowed.ToString()));
            });
    }
