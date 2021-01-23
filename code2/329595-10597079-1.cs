    Task.Factory.StartNew(() =>
    {
        // do something
        // do more stuff
        // done
    }).ContinueWith((completedTask) =>
    {
        // if you were computing a value with the task
        // you can now do something with it
        // this is like a callback method, but defined inline
        
        // use ui's dispatcher if you need to interact with ui compontents
        UI.Label.Dispatcher.Invoke(new Action(() =>
             UI.Item.Label.Text = completedTask.Result;
    }
