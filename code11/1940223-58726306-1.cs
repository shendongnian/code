    public void OnButtonClick()
    {
        var localCopyOfTheReference = someReference;
        var fireAndForget = Task.Run(async () =>
        {
            await Task.Delay(30000);
            Send(localCopyOfTheReference);
        });
    }
