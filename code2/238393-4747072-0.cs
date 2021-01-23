    using System;
    using System.Runtime.InteropServices;
    namespace clipboard
    {
        class Program
        {
            public static void Main(string[] args)
            {
                ConsoleKeyInfo ki = Console.ReadKey( true );
                if( ( ki.Key == ConsoleKey.V ) && ( ki.Modifiers == ConsoleModifiers.Control ) )
                {
                    Console.WriteLine( "Ctrl+V pressed" );
                    string s = ClipBoard.PasteTextFromClipboard();
                    Console.WriteLine( s );
                }
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
            }
        }
        class ClipBoard
        {
            [DllImport("user32.dll", SetLastError = true)]
            private static extern Int32 IsClipboardFormatAvailable( uint format );
            [DllImport("user32.dll", SetLastError = true)]
            private static extern Int32 OpenClipboard( IntPtr hWndNewOwner );
            [DllImport("user32.dll", SetLastError = true)]
            private static extern IntPtr GetClipboardData( uint uFormat );
            [DllImport("user32.dll", SetLastError = true)]
            private static extern Int32 CloseClipboard();
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern string GlobalLock( IntPtr hMem );
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern Int32 GlobalUnlock( IntPtr hMem );
            const uint CF_TEXT = 1;
            public static string PasteTextFromClipboard()
            {
                string result = "";
                if( IsClipboardFormatAvailable( CF_TEXT ) == 0 )
                {
                    return result; 
                }
                if( OpenClipboard((IntPtr)0) == 0 )
                {
                    return result; 
                }
                IntPtr hglb = GetClipboardData(CF_TEXT);
                if( hglb != (IntPtr)0 )
                {
                    string s = GlobalLock(hglb);
                    if( s != null )
                    {
                        result = s;
                        GlobalUnlock(hglb);
                    }
                }
                CloseClipboard();
                return result;
            }
        }
    }
