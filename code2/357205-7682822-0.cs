     string bookTitle = "test"; // The book title that you want to close.
     Process[] AllProcesses = Process.GetProcessesByName("excel");
     foreach (var process in AllProcesses)
     {
        string tempTitle = process.MainWindowTitle.Split('-')[1].TrimStart();
        if (bookTitle == tempTitle)
            {
                process.Kill();
            }
     }
