    class ThreadTest
    {
        static void Main()
        {
             for(int i = 0; i < 10; i++)
             {
                  int j = i;
                  new Thread(() => Console.Write(j)).Start();
             }
        }
    } 
