    public void SomeLongRunningTask()
    {
        System.Threading.Thread.Sleep(5000);
        Application.Current.Dispatcher((Action)(() => LoggingList.Add(new CustomMessage("Completed long task!"))));
    }
