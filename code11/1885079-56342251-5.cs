     static void Main(string[] args)
     {
         Task.Run(() => { Thread.Sleep(5000); Console.WriteLine("Spider Man: I don't wan't to go!"); });  // POOF!! 
         Console.WriteLine("I'm running after Task.Run");
         // sorry Spidy, you're dead
     }
