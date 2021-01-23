    public void SomeLongRunningTask()
    {
        System.Threading.Thread.Sleep(5000);
        Application.Current.Dispatcher.BeginInvoke((Action)(() => LoggingList.Add(new CustomMessage("Completed long task!"))));
    }
