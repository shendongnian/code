    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Interop;
    
    static class WindowExt
    {
    	// http://www.pinvoke.net/default.aspx/user32.movewindow
    	[DllImport( "user32.dll", SetLastError = true )]
    	static extern bool MoveWindow( IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint );
    
    	public static void moveWindow( this Window window, Rectangle rect )
    	{
    		var wih = new WindowInteropHelper( window );
    		IntPtr hWnd = wih.Handle;
    		MoveWindow( hWnd, rect.Left, rect.Top, rect.Width, rect.Height, false );
    	}
    }
