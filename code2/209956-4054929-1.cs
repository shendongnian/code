        private static void RetroConsoleWriteLine()
        {
            const string message = "Enter your user name...";
            var r = new Random();
            foreach (var c in message)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(r.Next(50,300));
            }
            Console.ReadLine();
        }
