    private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            FileSystemWatcher Watcher = new FileSystemWatcher();
            Watcher.Path = @"C:\Images";
            Watcher.Created += new FileSystemEventHandler(Watcher_Changed);
            Watcher.EnableRaisingEvents = true;
        }
    private void Watcher_Changed(object sender, FileSystemEventArgs e)
    {
        try
        {
            using (PrintDocument myDoc = new PrintDocument())
            {
                myDoc.PrintPage += new PrintPageEventHandler(print);
                FilePath = e.FullPath;
                myDoc.PrinterSettings.PrinterName = @"\\Network Printer";
                myDoc.Print();
                using (StreamWriter sw = new StreamWriter("C:\\error.txt"))
                {
                     sw.WriteLine("Printed File: " + FilePath);
                }
            }
            File.Delete(e.FullPath);
        }
        catch(Exception excep)
        {
            using (StreamWriter sw = new StreamWriter("C:\\error.txt"))
            {
                sw.WriteLine("Error: " + excep.ToString());
            }
        }
    }
