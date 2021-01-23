        private static void RetroConsoleWriteLine()
        {
            const string message = "Enter your user name...";
            var r = new Random();
            Action<char> action = c =>
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(r.Next(50, 300));
            };
            message.ToList().ForEach(action);
            Console.ReadLine();
        }
