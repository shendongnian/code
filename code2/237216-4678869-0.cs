    private void bcCharter_DoWork(object sender, DoWorkEventArgs e)
    {
        Chart chart = null;
        Dispatcher.Invoke(DispatcherPriority.Normal,
            new Action(() =>
                {
                    chart.Series.Clear();
                }));
    }
