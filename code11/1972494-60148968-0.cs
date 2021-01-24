    public static event Action OnEmptyPrintQueue;
    private static void Main(string[] args)
    {
        new Task(() =>
        {
            var wasEmpty = true;
            while (true)
            {
                if (wasEmpty && NumberOfJobs > 0)
                {
                    wasEmpty = false;
                }
                else if (!wasEmpty && NumberOfJobs == 0)
                {
                    wasEmpty = true;
                    OnEmptyPrintQueue?.Invoke();
                }
            }
        }, TaskCreationOptions.LongRunning).Start();
    }
