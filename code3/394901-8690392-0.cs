    var processes = System.Diagnostics.Process.GetProcessesByName("notepad");
    foreach (System.Diagnostics.Process process in processes)
    {
        // The main window handle can now be accessed 
        // through process.MainWindowHandle;
    }
