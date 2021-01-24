        static void Main(string[] args)
        {
            Console.WriteLine("The stopwatch, press S to begin and Q to stop");
            var UserInput = Console.ReadLine();
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
        Decide:
            switch (UserInput.ToLower())
            {
                case "s":
                    stopWatch.Start();
                    while (!Console.KeyAvailable)
                    {
                        // Get the elapsed time as a TimeSpan value.
                        TimeSpan ts = stopWatch.Elapsed;
                        Console.Clear();
                        // Format and display the TimeSpan value. 
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 2);
                        Console.WriteLine("RunTime " + elapsedTime);
                        Thread.Sleep(1000);
                    }
                    UserInput = Console.ReadLine();
                    if (UserInput.ToLower() != "q")
                    {
                        goto Decide;
                    }
                    break;
                case "q":
                    stopWatch.Stop();
                    break;
                default:
                    Console.WriteLine("You did something wrong");
                    break;
            }
        }
