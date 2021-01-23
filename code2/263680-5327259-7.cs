    private void PerformAsync(Action action, Control triggeringControl)
    {
        ThreadPool.QueueUserWorkItem(state => {
            Dispatcher.BeginInvoke((Action)delegate() { triggeringControl.IsEnabled = false; });
            action();
            Dispatcher.BeginInvoke((Action)delegate() { triggeringControl.IsEnabled = true; });     
        });
    }
