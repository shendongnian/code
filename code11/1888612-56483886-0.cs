    public void YourTask()
    {
        // do calculations and get results
        Application.Current.Dispatcher.Invoke(
            new Action(() =>
            {
                // update the UI
            }));
    }
