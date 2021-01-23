     CancellationTokenSource cts = new CancellationTokenSource();
     Task.Factory.StartNew(() =>
        {
             if(cts.Token.IsCancellationRequested)
                return;
             // Do Stuff
        });
