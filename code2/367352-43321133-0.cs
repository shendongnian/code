    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
    	class Program
    	{
    		[DllImport( "kernel32.dll", SetLastError = true )]
    		public static extern bool SetConsoleMode( IntPtr hConsoleHandle, int mode );
    		[DllImport( "kernel32.dll", SetLastError = true )]
    		public static extern bool GetConsoleMode( IntPtr handle, out int mode );
    
    		[DllImport( "kernel32.dll", SetLastError = true )]
    		public static extern IntPtr GetStdHandle( int handle );
    
    		static void Main( string[] args )
    		{
    			var handle = GetStdHandle( -11 );
    			int mode;
    			GetConsoleMode( handle, out mode );
    			SetConsoleMode( handle, mode | 0x4 );
    
    			for (int i=0;i<255;i++ )
    			{
    				Console.Write( "\x1b[48;5;" + i + "m*" );
    			}
    
    			Console.ReadLine();
    		}
    	}
    }
