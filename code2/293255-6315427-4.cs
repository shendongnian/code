    [StructLayout(LayoutKind.Sequential)]
    public struct MINMAXINFO
    {
        public POINT ptReserved;
        public POINT ptMaxSize;
        public POINT ptMaxPosition;
        public POINT ptMinTrackSize;
        public POINT ptMaxTrackSize;
    } ;
    public enum MonitorFromWindowFlags
    {
        MONITOR_DEFAULTTONEAREST = 0x00000002
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class MONITORINFO
    {
        public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));
        public RECT rcMonitor;
        public RECT rcWork;
        public int dwFlags;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
        public static readonly RECT Empty;
        public int Width
        {
            get
            {
                return Math.Abs(this.Right - this.Left);
            } // Abs needed for BIDI OS
        }
        public int Height
        {
            get
            {
                return this.Bottom - this.Top;
            }
        }
        public RECT(int left, int top, int right, int bottom)
        {
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }
        public RECT(RECT rcSrc)
        {
            this.Left = rcSrc.Left;
            this.Top = rcSrc.Top;
            this.Right = rcSrc.Right;
            this.Bottom = rcSrc.Bottom;
        }
        public bool IsEmpty
        {
            get
            {
                // BUGBUG : On Bidi OS (hebrew arabic) left > right
                return this.Left >= this.Right || this.Top >= this.Bottom;
            }
        }
        public override string ToString()
        {
            if (this == Empty)
            {
                return "RECT {Empty}";
            }
            return "RECT { left : " + this.Left + " / top : " + this.Top + " / right : " + this.Right + " / bottom : " +
                   this.Bottom + " }";
        }
        public override bool Equals(object obj)
        {
            if (!(obj is RECT))
            {
                return false;
            }
            return (this == (RECT)obj);
        }
        public override int GetHashCode()
        {
            return this.Left.GetHashCode() + this.Top.GetHashCode() + this.Right.GetHashCode() +
                   this.Bottom.GetHashCode();
        }
        public static bool operator ==(RECT rect1, RECT rect2)
        {
            return (rect1.Left == rect2.Left && rect1.Top == rect2.Top && rect1.Right == rect2.Right &&
                    rect1.Bottom == rect2.Bottom);
        }
        public static bool operator !=(RECT rect1, RECT rect2)
        {
            return !(rect1 == rect2);
        }
    }
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);
