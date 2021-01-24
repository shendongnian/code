    public static bool WaitAll (System.Threading.Tasks.Task[] tasks, int millisecondsTimeout);
    public void MultipleThread(List<string> list)
    {
        List<Task> listTask = new List<Task>();
        foreach (string item in list)
        {
            listTask.Add(Task.Factory.StartNew(() => SetAddress(item)));
        }
        Task.WaitAll(listTask.ToArray(), 50000);
    }
 
