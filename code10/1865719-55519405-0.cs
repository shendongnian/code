public class SimpleSingleton
{
    private static Task<int> executingTask;
    private static object lockObject = new object();
    public async Task<int> GetRefreshedValue()
    {
        lock (lockObject)
            {
                if (executingTask == null || executingTask.IsCompleted)
                {
                    executingTask = GetRefreshedValueImplementation();
                }
            }
        return await executingTask;
    }
    private async Task<int> GetRefreshedValueImplementation()
    {
        /*
           Resource intensive and not thread safe
        */
    }
}
