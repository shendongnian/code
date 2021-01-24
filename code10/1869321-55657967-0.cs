    delegate void SomeTimeLaterDelegate(int myValue);
    static event SomeTimeLaterDelegate SomeTimeLater;
    static Queue<int> SomeTimeLaterQueue = new Queue<int>(); // Here we store the event arguments
    static async Task Main(string[] args)
    {
        SomeTimeLater += new SomeTimeLaterDelegate(AnswerAnotherDay); // Subscribe to the event
        await Task.Delay(100);
        OnSomeTimeLaterDefered(10); // Raise an defered event
        await Task.Delay(100);
        OnSomeTimeLaterDefered(20); // Raise another defered event
        await Task.Delay(100);
        OnSomeTimeLaterDefered(30); // Raise a third defered event
        await Task.Delay(100);
        OnSomeTimeLaterFlush(); // Time to raise the queued events for real!
    }
    static void OnSomeTimeLaterDefered(int value)
    {
        SomeTimeLaterQueue.Enqueue(value);
    }
    static void OnSomeTimeLaterFlush()
    {
        while (SomeTimeLaterQueue.Count > 0)
        {
            SomeTimeLater?.Invoke(SomeTimeLaterQueue.Dequeue());
        }
    }
    static void AnswerAnotherDay(int howManyDays)
    {
        Console.WriteLine($"I did this {howManyDays}, later. Hurray for procrastination!");
    }
