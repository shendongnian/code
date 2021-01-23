    private void UpdateCountInBackground()
    {
        Task.Factory.StartNew(
            () =>
            {
                int current = 0, allowed = 0;
                Task t1 = Task.Factory.StartNew<int>(func1).ContinueWith(t => { current = t.Result; });
                Task t2 = Task.Factory.StartNew<int>(func2).ContinueWith(t => { allowed = t.Result; });
                Task.WaitAll(t1, t2);
                Invoke(new Action(() => 
                    labelCount.Text = "Using " + current.ToString() + " of " + allowed.ToString()));
            });
    }
