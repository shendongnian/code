    string[] forums = File.ReadAllLines(Environment.CurrentDirectory + @"\forums.txt");
    Task[] tasks = new Task[forums.Length ];
    int ctr = 0;
    DateTime Start = DateTime.Now;`
    foreach(string s in forums)`
    {
    object state = s;
    var task = Task.Factory.StartNew(() => DoSomeWork(state),TaskCreationOptions.LongRunning);
    tasks[ctr] = task;
    ctr++;
    }
    Task.WaitAll(tasks);
    DateTime end = DateTime.Now;
    TimeSpan elapsed = end - Start;
    string totalMs = elapsed.TotalMilliseconds.ToString();
    Console.WriteLine("DONE in " +totalMs + " ms. Any Key to quit.");
    Console.ReadKey();
