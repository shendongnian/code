    public void DrawLines(System.Drawing.Color color, ref System.Drawing.Point[] points, int pointsCount)
        {
            IntPtr pen = IntPtr.Zero;
            int status = GdipCreatePen1(
                                    color.ToArgb(),
                                    1,
                                    (int)GraphicsUnit.World,
                                    out pen);
            unsafe
            {
                fixed (Point* pointerPoints = points)
                {
                    status = GdipDrawLinesI(new HandleRef(this, this.handleGraphics), new HandleRef(this, pen), (IntPtr)pointerPoints, pointsCount);
                }
            }
            status = GdipDeletePen(new HandleRef(this, pen));
        }
        
        [DllImport(GDIPlusDll, SetLastError = true, ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode)] 
        private static extern int GdipDrawLinesI(HandleRef graphics, HandleRef pen, IntPtr points, int count);        
        [DllImport(GDIPlusDll, SetLastError = true, ExactSpelling = true)]
        private static extern int GdipDeletePen(HandleRef pen);
        [DllImport(GDIPlusDll, SetLastError = true, ExactSpelling = true)]
        private static extern int GdipCreatePen1(int argb, float width, int unit, out IntPtr pen);
