     // C# 7
     static async void Main(string[] args)
     {
         await Task.Run(() => { Thread.Sleep(5000); Console.WriteLine("I'm running 
                     after Thread.Sleep"); });
         Console.WriteLine("I'm running after Task.Run");
     }
