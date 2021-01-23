    public static List<string> pro_hook = list_all_processes();
    protected static List<string> list_all_processes()
    {
        var list = new List<string>();
        foreach (Process i in Process.GetProcesses(".")) {
            try {
                foreach (ProcessModule pm in i.Modules) {
                    list.Add(pm.FileName);
                }
            } catch { }
        }
        return list;
    }
