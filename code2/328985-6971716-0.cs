    static void Main()
    {
        Test();
        Console.ReadLine(); // so the exe doesn't burninate
    }
    static async void Test() {
        Task<string> task = TaskEx.Run(
               () =>
               {
                   Thread.Sleep(5000);
                   return "Hello World";
               });
        string str = await task;
        Console.WriteLine(str);
    }
