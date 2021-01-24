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
            //We probably need `Unwrap()` here. Can't remember
            var result=t.Unwrap().Result;
            textBox.Text=String.Format("The result is {0}",result);
        },TaskScheduler.FromCurrentSynchronizationContext());
