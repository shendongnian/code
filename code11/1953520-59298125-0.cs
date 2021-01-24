    var task = Task.Factory.StartNew(() =>
    {
        foreach(int patient in patients)
        {
            var message = BuildCommand();
            var bytes = Socket.StartClient(message);
            var bits = new BitArray(bytes);
            var stringBytes = ToBitString(bits);
            SetResultsText(stringBytes + Environment.NewLine);
        }
    }, TaskCreationOptions.LongRunning);
    await task;
