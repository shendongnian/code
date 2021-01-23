    progressBar1.Minimum = 0;
    progressBar1.Maximum = Results.Count;
    foreach (MyClass cls in Results)
    {
        ThreadPool.QueueUserWorkItem((o) =>
                 {
                     progressBar1.Dispatcher.BeginInvoke(
                         (Action) (() => progressBar1.Value += 1));
                     cls.GetHistoryData();
                 });
    }
