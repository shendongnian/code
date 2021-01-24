        private static void Watcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            string filePath = e.FullPath;
            DateTime writeDate = System.IO.File.GetLastWriteTime(filePath);
            if (lastWriteDate.ContainsKey(filePath))
            {
                if (lastWriteDate[filePath] == writeDate) 
                    //Exit as we already have raised an event for this
                    return;
                lastWriteDate[filePath] = writeDate;
            }
            else
            {
                lastWriteDate.Add(filePath, writeDate);
            }
            //Do your stuff.
        }
