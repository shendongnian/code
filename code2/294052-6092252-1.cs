    public static ListViewItem[] GetProcessData()
    {
        return Process.GetProcesses()
            .Where(arg => arg.Id != 0 && !arg.ProcessName.ToLower().Contains("system"))
            .Select(arg => new ListViewItem(new[] { arg.MainModule.ModuleName, arg.Id.ToString() }))
            .ToArray();
    }
