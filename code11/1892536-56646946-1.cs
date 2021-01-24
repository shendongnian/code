    Task.Factory.StartNew(() => LongerOperation())
        .ContinueWith(t=>
        {
            if (!t.IsFaulted)
            {
                return anotherLongOperation(t.Result);
            }
            else
            {
                //?? What do we do here?
                //Pass the buck further down.
                return Task.FromException(t.Exception);
            }
        })         
        .ContinueWith(t =>
        {
            textBox.Text=String.Format("The result is {0}",t.Result);
        },TaskScheduler.FromCurrentSynchronizationContext());
