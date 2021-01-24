    var first = true;
    foreach(int patient in patients)
    {
        if (!first)
        {
            await Task.Delay(200);
        }
        await Task.Run(() =>
        {
            var message = BuildCommand();
            var bytes = Socket.StartClient(message);
            var bits = new BitArray(bytes);
            var stringBytes = ToBitString(bits);
    
            SetResultsText(stringBytes + Environment.NewLine);
        });
     }
