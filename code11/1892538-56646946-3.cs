    Task.Factory.StartNew(() => LongerOperation())
    .ContinueWith(t=>
    {
        if (!t.IsFaulted)
        {
            var num=anotherLongOperation(t.Result);
            if (num<0)
            {
                //Now what?
                //Let's return a "magic" value
                return Task.FromResult(null);
            }
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
        //This may need t.Result.Result
        if (!t.IsFaulted && t.Result!=null)
        {
            textBox.Text=String.Format("The result is {0}",t.Result);
        }
    },TaskScheduler.FromCurrentSynchronizationContext());
