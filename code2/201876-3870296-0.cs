    void Form1_Paint(object sender, PaintEventArgs e)
            {
                //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
    
                using ( redPen )
                {
                    p05.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    p05.DashPattern = dashPattern;
                    e.Graphics.DrawLine(redPen, startingPoint, endingPoint);
                }
            }
    
    private PointF startingPoint = new PointF(121.0F, 106.329636F);
    private PointF endingPoint = new PointF(0.9999999F, 106.329613F);
    private Pen redPen = new Pen(Color.Red, 1F);
    private float[] dashPattern = { 4, 2, 1, 3 };
