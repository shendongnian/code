    static void Main()
    {
      new Thread(() => SetUpTimer(
         new TimeSpan(20, 07,
             50))).Start();
      lock (locker)
      {
        Console.WriteLine("give me your name");
        string a = Console.ReadLine();
        Console.WriteLine(a);
      }
    }
