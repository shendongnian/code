    static object countLock = new object();
    public static void printWithLock()
    {
        // loop forever
        while(true)
        {
            // protect access to count using a static object
            // now only 1 thread can use 'count' at a time
            lock (countLock)
            {
                if (count >= max) return;
                Console.WriteLine(Thread.CurrentThread.Name + " - " + count.ToString());
                count++;
            }
        }
    }
