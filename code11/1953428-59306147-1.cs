    delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);
    [DllImport("user32.dll")]
    static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn, IntPtr lParam);
    [DllImport("user32.dll")]
    static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
    static IEnumerable<IntPtr> GetModalWindowsHandles(int processId)
    {
        var handles = new List<IntPtr>();
        foreach (ProcessThread thread in Process.GetProcessById(processId).Threads)
            EnumThreadWindows(thread.Id,
                (hWnd, lParam) =>
                {
                    var className = new StringBuilder(256);
                    GetClassName(hWnd, className, 256);
                    if (className.ToString() == "#32770")
                    {
                        handles.Add(hWnd);
                    }
                    return true;
                }, IntPtr.Zero);
        foreach (Form form in Application.OpenForms)
            form.Invoke(new Action(() =>
            {
                if (form.Modal)
                    handles.Add(form.Handle);
            }));
        return handles;
    }
