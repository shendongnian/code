        var random = new Random();
        var resultA = new List<int>();
        for (int i = 0; i < 1000; i++)
        {
            resultA.Add(random.Next(5));
        }
        var resultB = new List<int>();
        for (int i = 0; i < 1000; i++)
        {
            resultB.Add(random.Next(5));
            Thread.Sleep(1);
        }
