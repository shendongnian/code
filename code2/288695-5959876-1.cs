    private void ReadMessageAsync()
    {
        // Set up the task to read the message from the hardware device.
        Task<string> readMessageTask = new Task<string>(ReadMessage);
        // Set up the task to process the message when the message was read from the device.
        readMessageTask.ContinueWith(ProcessMessage);
        // Start the task asynchronously.
        readMessageTask.Start();
    }
    private void ProcessMessage(Task<string> readMessageTask)
    {
        string message = readMessageTask.Result;
        // Process the message
    }
    private string ReadMessage()
    {
        string message = string.Empty;
        // Retrieve the message using your loop
        return message;
    }
