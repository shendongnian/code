        static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            for (int x = 0; x <= 500000; x++)
            {
                int t = x;
            }
            Console.WriteLine(File.ReadLines(e.FullPath).Last());
        }
