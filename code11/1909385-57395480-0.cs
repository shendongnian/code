    private async Task DoWorkNotReallyAsync()
    {
        for (int i = 0; i < aVeryLargeNumber; i++)
        {
            DoSynchronousComputation();
        }
    }
