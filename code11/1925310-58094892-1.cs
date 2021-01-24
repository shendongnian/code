       private void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventArgs)
            {
    
                //...now, lets update the "session" with some new content!
                eventArgs.Session.UpdateContent(new ProgressDialog());
                //note, you can also grab the session when the dialog opens via the DialogOpenedEventHandler
    
               
    
                //lets run a fake operation for 3 seconds then close this baby.
                Task.Delay(TimeSpan.FromSeconds(3))
                    .ContinueWith((t, _) => eventArgs.Session.Close(false), null,
                       TaskScheduler.FromCurrentSynchronizationContext());
            }
