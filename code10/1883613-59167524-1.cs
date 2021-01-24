       private static int ArgbToRGB(int rgb)
       {
        return ((rgb >> 16 & 0x0000FF) | (rgb & 0x00FF00) | (rgb << 16 & 0xFF0000));
        }
        public enum PenStyles
        {
            PS_OLID = 0,
            PS_DASH = 1,
            PS_DOT = 2,
            PS_DASHDOT = 3,
            PS_DASHDOTDOT = 4,
            PS_NULL = 5,
            PS_INSIDEFRAME = 6,
            PS_USERSTYLE = 7,
            PS_ALTERNATE = 8,
            PS_STYLE_MASK = 0x0000000F,
            PS_ENDCAP_ROUND = 0x00000000,
            PS_ENDCAP_SQUARE = 0x00000100,
            PS_ENDCAP_FLAT = 0x00000200,
            PS_ENDCAP_MASK = 0x00000F00,
            PS_JOIN_ROUND = 0x00000000,
            PS_JOIN_BEVEL = 0x00001000,
            PS_JOIN_MITER = 0x00002000,
            PS_JOIN_MASK = 0x0000F000,
            PS_COSMETIC = 0x00000000,
            PS_GEOMETRIC = 0x00010000
            PS_TYPE_MASK = 0x000F0000
        }
        public enum GDIDrawingMode
        {
            R2_BLACK = 1,
            R2_NOTMERGEPEN = 2,
            R2_MASKNOTPEN = 3,
            R2_NOTCOPYPEN = 4,
            R2_MASKPENNOT = 5,
            R2_NOT = 6,
            R2_XORPEN = 7,
            R2_NOTMASKPEN = 8,
            R2_MASKPEN = 9,
            R2_NOTXORPEN = 10,
            R2_NOP = 11,
            R2_MERGENOTPEN = 12,
            R2_COPYPEN = 13,
            R2_MERGEPENNOT = 14,
            R2_MERGEPEN = 15,
            R2_WHITE = 16            
        }
    [DllImport("gdi32.dll", CharSet = CharSet.Auto, EntryPoint = "Rectangle", ExactSpelling = true, SetLastError = true)]
    public static extern bool GDIDrawRectangle(IntPtr hDC, int left, int top, int right, int bottom);
    [DllImport("gdi32.dll")]
    public static extern int SetROP2(IntPtr hDC, int fnDrawMode);
    [DllImport("gdi32.dll")]
    public static extern bool MoveToEx(IntPtr hDC, int x, int y, ref Point p);
    [DllImport("gdi32.dll")]
    public static extern bool LineTo(IntPtr hdc, int x, int y);
    [DllImport("gdi32.dll")]
    public static extern IntPtr CreatePen(int fnPenStyle, int nWidth, int crColor);
    [DllImport("gdi32.dll")]
    public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObj);
    [DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hObj);
    public static void DrawXORRectangle(Graphics graphics, Color penColor, Rectangle rectangle)
        {            
            IntPtr hDC = graphics.GetHdc();
            IntPtr hPen = CreatePen((int)PenStyles.PS_DOT, 1, ArgbToRGB(penColor.ToArgb()));
            IntPtr hOldPen = SelectObject(hDC, hPen);
            SetROP2(hDC, (int)GDIDrawingMode.R2_NOTXORPEN);
            GDIDrawRectangle(hDC, rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
            SelectObject(hDC, hOldPen);
            DeleteObject(hPen);
            graphics.ReleaseHdc(hDC);
        }
