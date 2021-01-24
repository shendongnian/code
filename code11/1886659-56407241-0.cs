        static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            var lines = File.ReadLines(e.FullPath);
            Console.WriteLine(lines.Last());
            lines.GetEnumerator().Dispose();
        }
This should guarantee disposal before the end of event handler.
