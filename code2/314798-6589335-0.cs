        t = int.Parse(Console.ReadLine());
        count = 0;
        Result = DateTime.Now;
        List<Thread> MyThreads = new List<Thread>();
        for (int i = 1; i < 31; i++)
        {
            Thread Temp = new Thread(print);
            Temp.Name = i.ToString();
            MyThreads.Add(Temp);
        }
