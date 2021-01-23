	NetworkStream stream = MySocket.NetworkStream;
	
	// creat a Task<int> returning the number of bytes red based on the Async patterned Begin- and EndRead methods of the Stream
    Task<int> task = Task<int>.Factory.FromAsync(
            fs.BeginRead, fs.EndRead, data, 0, data.Length, null);
    // Add the continuation, which returns a Task<string>. 
    return task.ContinueWith((task) =>
    {
        if (task.IsFaulted)
        {
            ExceptionTextBox.Text = task.Exception.Message;
        }
        else 
        {
            ResultTextBox.Text = string.Format("Red {0} bytes into data", task.Result);
        }
	}, TaskScheduler.FromCurrentSynchronizationContext());
