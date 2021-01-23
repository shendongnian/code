    string dlCode;
    if (blockingCollection.TryTake(out dlCode))
    {       
        Dispatcher.Invoke(() =>
        {
             TxtBlock3.Text = dlCode; 
        }
    }
             
