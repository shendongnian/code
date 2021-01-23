    ...
    static void Main(string[] args)
    {
        using (PCQueue q = new PCQueue(2))
        {
            q.ItemProcessed += ItemProcessed;
            q.TaskCompleted += OnTaskCompleted;
            for (int i = 1; i <= totalNumberOfItems; i++)
            {
                string itemNumber = i.ToString(); // To avoid the captured variable trap
                q.EnqueueItem(itemNumber);
            }
            Console.WriteLine("Waiting for items to complete...");
            Console.Read();
        }
    }
    private static int currentProcessCount = 0;
    private static int totalNumberOfItems = 100;
    private static void ItemProcessed(object sender, EventArgs e)
    {
         currentProcessCount++;
         Console.WriteLine("Progress: {0}%", (currentProcessCount / totalNumberOfItems) * 100);
    }
    static void OnTaskCompleted(object sender, EventArgs e)
    {
         Console.WriteLine("Done");
    }
    ...
