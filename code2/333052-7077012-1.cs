    using System.Runtime.InteropServices;
    using System;
    [StructLayout(LayoutKind.Sequential)]
    struct RECT
    {
         public int L;
         public int T;
         public int R;
         public int B;
    }
    
    static class Program
    {
    	void Main()
    	{
    		RECT r;
    		bool result = GetWindowRect(0x00120E34, out r);
    		Console.WriteLine("{0}: {1} {2} {3} {4}", r.T, r.L, r.B, r.R);
    	}
    
    	[DllImport("user32.dll")]
    	[return: MarshalAs(UnmanagedType.Bool)]
    	extern bool GetWindowRect(int hwnd, out RECT lpRect);
    }
