    static ConsoleKeyInfo cki = new ConsoleKeyInfo();
    while(true) {
          if (WaitOrBreak()) break;
          //your main code
    }
     private static bool WaitOrBreak(){
            if (Console.KeyAvailable) cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.Spacebar)
            {
                Console.Write("waiting..");
                while (Console.KeyAvailable == false)
                {
                    Thread.Sleep(250);Console.Write(".");
                }
                Console.WriteLine();
                Console.ReadKey(true);
                cki = new ConsoleKeyInfo();
            }
            if (cki.Key == ConsoleKey.Escape) return true;
            return false;
        }
