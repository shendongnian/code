    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GetCursorPos(out POINT lpPoint);
            
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    
        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    
    private void WritePoint(object sender, RoutedEventArgs e)
    {
        POINT p;
        if (GetCursorPos(out p))
        {
            System.Console.WriteLine(Convert.ToString(p.X) + ";" + Convert.ToString(p.Y));
        }
    }
