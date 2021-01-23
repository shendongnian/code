    using System;
    using System.IO;
    using System.Collections.Generic; //for dictionary
    using System.Runtime.InteropServices; //for P/Invoke DLLImport
    
    class App
    {
    
            /// <summary>
            /// Contains native methods imported as unmanaged code.
            /// </summary>
            internal static class DllImports
            {
                [StructLayout(LayoutKind.Sequential)]
                public struct COORD
                {
    
                    public short X;
                    public short Y;
                    public COORD(short x, short y) { 
                        this.X = x;
                        this.Y = y;
                    }
    
                }
                [DllImport("kernel32.dll")]
                public static extern IntPtr GetStdHandle(int handle);
                [DllImport("kernel32.dll", SetLastError = true)]
                public static extern bool SetConsoleDisplayMode(
                    IntPtr ConsoleOutput
                    ,uint Flags
                    ,out COORD NewScreenBufferDimensions
                    );
            }
            /// Main App's Entry point
    		public static void Main (string[] args)
    		{
                IntPtr hConsole = DllImports.GetStdHandle(-11);   // get console handle
                DllImports.COORD xy = new DllImports.COORD(100,100);
                DllImports.SetConsoleDisplayMode(hConsole, 1, out xy); // set the console to fullscreen
                //SetConsoleDisplayMode(hConsole, 2);   // set the console to windowed
    
    		}
    }
