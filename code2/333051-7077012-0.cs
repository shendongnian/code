    using System.Console;
    using System.Runtime.InteropServices;
    using PInvoke;
    
    [StructLayout(LayoutKind.Sequential)]
    struct RECT
    {
         public L : int;
         public T : int;
         public R : int;
         public B : int;
    }
    
    module PInvoke
    {
    	[DllImport("user32.dll")]
    	[return: MarshalAs(UnmanagedType.Bool)]
    	public extern GetWindowRect(hwnd : int, lpRect : out RECT) : bool;
    }
    
    mutable r;
    def result = GetWindowRect(0x00120E34, out r);
    WriteLine($"$result: $(r.T) $(r.L) $(r.B) $(r.R)");
