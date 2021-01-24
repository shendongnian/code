            t1 = new System.Timers.Timer {
                Interval = myAttackSpeed*10,
                Enabled = true,
                Elapsed += OnT1Elapsed
            };
            t2 = new System.Timers.Timer {
                Interval = yourAttackSpeed*10,
                Enabled = true,
                Elapsed += OnT2Elapsed
            };
            Console.WriteLine("Press the Enter key to exit the program at any time... ");    
            Console.ReadLine(); 
        } 
        private static void OnT1Elapsed(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("My attack"); 
         }
        private static void OnT2Elapsed(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Your attack"); 
         }
    }
