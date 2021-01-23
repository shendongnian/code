    const int n = 3;
    static void Main(string[] args)
    {
        for (int i = 0; i < n; i++)
        {
            var start = GetDefaultBrowserStartInfo("http");
            start.Arguments += string.Format(" http://localhost/#{0}", i);
            
            var p = Process.Start(start);
        }
    }
    static ProcessStartInfo GetDefaultBrowserStartInfo(string scheme)
    {
        string command = null;
        using (var key = Registry.ClassesRoot.OpenSubKey(string.Format(@"{0}\shell\open\command", scheme)))
        {
            command = (string)key.GetValue("");
        }
        string[] parsed = CommandLineToArgs(command);
        return new ProcessStartInfo
        {
            FileName = parsed[0],
            Arguments = string.Join(" ", parsed.Skip(1).ToArray()),
        };
    }
    [DllImport("shell32.dll", SetLastError = true)]
    static extern IntPtr CommandLineToArgvW(
        [MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine, out int pNumArgs);
    static string[] CommandLineToArgs(string commandLine)
    {
        int argc;
        var argv = CommandLineToArgvW(commandLine, out argc);
        if (argv == IntPtr.Zero)
            throw new System.ComponentModel.Win32Exception();
        try
        {
            var args = new string[argc];
            for (var i = 0; i < args.Length; i++)
            {
                var p = Marshal.ReadIntPtr(argv, i * IntPtr.Size);
                args[i] = Marshal.PtrToStringUni(p);
            }
            return args;
        }
        finally
        {
            Marshal.FreeHGlobal(argv);
        }
    }
}
