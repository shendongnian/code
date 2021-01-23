    var tasks = new List<Task<int>>();
    for (var i = 0; i < 10; i++)
    {
        var num = i;
        var task = Task<int>.Factory.StartNew(() =>
            {
                if (num == 3)
                {
                    Thread.Sleep(20000);
                }
                Thread.Sleep(new Random(num).Next(1000, 10000));
                Console.WriteLine("Done {0} on {1}", num, Thread.CurrentThread.ManagedThreadId);
                return num;
             });
        tasks.Add(task);
    }
    TaskFactory.ContinueWhenAll(
        tasks.ToArray(), 
        (values) => values.ToList().ForEach(
                        value => Console.WriteLine(
                            "Completed {0} on {1}",
                            value.Result,
                            Thread.CurrentThread.ManagedThreadId)));
    Console.WriteLine("End of Main");
    Console.ReadKey();
