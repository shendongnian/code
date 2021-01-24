    using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\")) {
        string[] names = key.GetSubKeyNames();
        foreach (string entry in names) {
            Console.WriteLine(entry.ToString());
        }
    }
