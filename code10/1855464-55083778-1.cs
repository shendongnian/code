    static async Task Main(string[] args)
    {
       Console.WriteLine("Start Task");
       var task = Program.step1();
    
       for (int i = 0; i < 6; i++)
       {
          await Task.Delay(100);
          Console.WriteLine("Sleep-Loop");
       }
    
       Console.WriteLine("waiting for the task to finish");
       await task;
       Console.WriteLine("finished");
       Console.ReadKey();
    }
    
    private static async Task step1()
    {
       await Task.Delay(1000);
       Console.WriteLine("Step1");
       await Program.step2();
    }
    
    private static async Task step2()
    {
       await Task.Delay(1000);
       Console.WriteLine("Step2");
    }
