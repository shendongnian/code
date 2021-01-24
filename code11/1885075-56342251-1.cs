     static void Main(string[] args)
     {
         Task.Run(() => { Thread.Sleep(5000); Console.WriteLine("I'm running 
                     after Thread.Sleep"); });  // POOF!! 
         Console.WriteLine("I'm running after Task.Run");
         // bye bye task!  sleep or no sleep you're dead
     }
