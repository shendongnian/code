    for (int i = 1; i <= status.Count; i++)
    {
        action.DoubleClick(status[i]).Build().Perform();
        Thread.Sleep(2000);
    }
