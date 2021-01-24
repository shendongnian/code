        using (FileSystemWatcher watcher = new FileSystemWatcher())
        {
            watcher.Path = "C:\WhateverForlderIWantToMonitor";
            // Watch for changes in LastAccess and LastWrite times, and
            // the renaming of files or directories.
            watcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;
            // Watch every file
            watcher.Filter = "*";
            // Add event handlers.
            watcher.Created += OnCreated;
            // Begin watching.
            watcher.EnableRaisingEvents = true;
            // Wait for the user to quit the program.
            Console.WriteLine("Press 'q' to quit the sample.");
            while (Console.Read() != 'q') ;
        }
       // Define the event handlers.
       private static void OnChanged(object source, FileSystemEventArgs e) {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/octet-stream");
                using (Strea mfileStream = File.OpenRead(e.FullPath))
                using (Stream requestStream = client.OpenWrite(new Uri(fileUploadUrl), "POST"))
                {
                    fileStream.CopyTo(requestStream);
                }
            }
       }
