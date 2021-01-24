    public class Utsname
    {
        public string SysName; // char[65]
        public string NodeName; // char[65]
        public string Release; // char[65]
        public string Version; // char[65]
        public string Machine; // char[65]
        public string DomainName; // char[65]
        public void Print()
        {
            System.Console.Write("SysName:\t");
            System.Console.WriteLine(this.SysName);
            System.Console.Write("NodeName:\t");
            System.Console.WriteLine(this.NodeName);
            System.Console.Write("Release:\t");
            System.Console.WriteLine(this.Release);
            System.Console.Write("Version:\t");
            System.Console.WriteLine(this.Version);
            System.Console.Write("Machine:\t");
            System.Console.WriteLine(this.Machine);
            System.Console.Write("DomainName:\t");
            System.Console.WriteLine(this.DomainName);
            Mono.Unix.Native.Utsname buf;
            Mono.Unix.Native.Syscall.uname(out buf);
            System.Console.WriteLine(buf.sysname);
            System.Console.WriteLine(buf.nodename);
            System.Console.WriteLine(buf.release);
            System.Console.WriteLine(buf.version);
            System.Console.WriteLine(buf.machine);
            System.Console.WriteLine(buf.domainname);
        }
    }
    
    [System.Runtime.InteropServices.DllImport("libc", EntryPoint = "uname", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
    private static extern int uname_syscall(System.IntPtr buf);
    // https://github.com/jpobst/Pinta/blob/master/Pinta.Core/Managers/SystemManager.cs
    private static Utsname Uname()
    {
        Utsname uts = null;
        System.IntPtr buf = System.IntPtr.Zero;
        buf = System.Runtime.InteropServices.Marshal.AllocHGlobal(8192);
        // This is a hacktastic way of getting sysname from uname ()
        if (uname_syscall(buf) == 0)
        {
            uts = new Utsname();
            uts.SysName = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(buf);
            long bufVal = buf.ToInt64();
            uts.NodeName = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(new System.IntPtr(bufVal + 1 * 65));
            uts.Release = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(new System.IntPtr(bufVal + 2 * 65));
            uts.Version = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(new System.IntPtr(bufVal + 3 * 65));
            uts.Machine = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(new System.IntPtr(bufVal + 4 * 65));
            uts.DomainName = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(new System.IntPtr(bufVal + 5 * 65));
            if (buf != System.IntPtr.Zero)
                System.Runtime.InteropServices.Marshal.FreeHGlobal(buf);
        } // End if (uname_syscall(buf) == 0) 
        return uts;
    } // End Function Uname
