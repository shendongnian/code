        static void Main(string[] args)
        {
            ImportFileService ws = new ImportFileService();
            ws.OnStart(args);
            while (true)
            {
                ConsoleKeyInfo key = System.Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                    break;
            }
            ws.OnStop();
        }
