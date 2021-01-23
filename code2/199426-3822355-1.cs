            string sFile = e.FullPath;
            Console.WriteLine("processing file : " + sFile);
            // Wait if file is still open
            FileInfo fileInfo = new FileInfo(sFile);
            while(IsFileLocked(fileInfo))
            {
                Thread.Sleep(500);
            }
            string[] arrLines = File.ReadAllLines(sFile);
