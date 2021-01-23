    object writeListLocker = new object();
    List<string> linesToWrite = new List<string>();
    // Main thread loop
    for (; ; )
    {
        lock (writerListLocker)
        {
            foreach (string nextLine in linesToWrite)
                Console.WriteLine(nextLine);
            linesToWrite.Clear();
        }
        Thread.Sleep(500);
    }
    
    // Reporting threads
    lock (writerListLocker)
    {
        linesToWrite.Add("Completed (etc.)");
    }
