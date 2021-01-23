            DateTime t = new DateTime(0);
            Console.WriteLine("Enter # of seconds");
            string userSeconds = Console.ReadLine();
            t = t.AddSeconds(Int32.Parse(userSeconds));
            Console.WriteLine("As HH:MM:SS = {0}:{1}:{2}", t.Hour, t.Minute, t.Second);
