    // the only event we'll use:
    AutoResetEvent are = new AutoResetEvent(false);
    // starting threads:
    for (int i = 0; i < 10; i++)
    {
        string name = "T" + i; 
        new Thread(() => { while (true) { are.WaitOne(); WriteLine(name); } }).Start();
    }
     
    // release all threads and continue:
    while (!are.WaitOne(0))
        are.Set();
