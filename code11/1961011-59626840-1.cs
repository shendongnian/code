    private void MyEndlessTask()
    {
        while (true)
        {
            ct.ThrowIfCancellationRequested();
            Debug.Log("Running");
        }
    }
