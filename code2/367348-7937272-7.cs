    static void Main(string[] args)
        {
            Color screenTextColor = Color.Orange;
            Color screenBackgroundColor = Color.Black;
            int irc = SetScreenColorsApp.SetScreenColors(screenTextColor, screenBackgroundColor);
            Debug.Assert(irc == 0, "SetScreenColors failed, Win32Error code = " + irc + " = 0x" + irc.ToString("x"));
            Debug.WriteLine("LargestWindowHeight=" + Console.LargestWindowHeight + " LargestWindowWidth=" + Console.LargestWindowWidth);
            Debug.WriteLine("BufferHeight=" + Console.BufferHeight + " WindowHeight=" + Console.WindowHeight + " BufferWidth=" + Console.BufferWidth + " WindowWidth=" + Console.WindowWidth);
            //// these are relative to the buffer, not the screen:
            //Debug.WriteLine("WindowTop=" + Console.WindowTop + " WindowLeft=" + Console.WindowLeft);
            Debug.WriteLine("ForegroundColor=" + Console.ForegroundColor + " BackgroundColor=" + Console.BackgroundColor);
            Console.WriteLine("Some text in a console window");
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Debug.WriteLine("ForegroundColor=" + Console.ForegroundColor + " BackgroundColor=" + Console.BackgroundColor);
            Console.Write("Press ENTER to exit...");
            Console.ReadLine();
            // Note: If you use SetScreenColors, the RGB values of gray and black are changed permanently for the console window.
            // Using i.e. Console.ForegroundColor = ConsoleColor.Gray afterwards will switch the color to whatever you changed gray to
            // It's best to use SetColor for the purpose of choosing the 16 colors you want the console to be able to display, then use
            // Console.BackgroundColor and Console.ForegrondColor to choose among them.
        }
 
