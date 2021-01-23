    public static ListViewItem[] GetProcessData()
    {
        return Process.GetProcesses()
            .Where(arg => string.Equals(arg.ProcessName, "idle", StringComparison.OrdinalIgnoreCase))
            .Select(arg => new ListViewItem(new[] { arg.MainModule.ModuleName, arg.Id.ToString() }))
            .ToArray();
    }
