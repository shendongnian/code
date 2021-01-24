    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp9
    {
        public partial class Form1 : Form
        {
            const int initialRadius = 120; 
            const int centerX = 400; 
            const int centerY = 200;
            
            const double factor = 0.45; // Factor to determine the size of the next smaller radius
            
            const int recursionDepth = 5;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
    
                DrawRecursionStage(centerX, centerY, initialRadius, e.Graphics);
            }
    
            private void DrawRecursionStage(int x, int y, int radius, Graphics g)
            {
                if (IsRecursionDepthReached(radius))
                    return;
    
                DrawCircle(x, y, radius, g);
    
                int newRadius = (int)(radius * factor);
                DrawRecursionStage(x - radius, y, newRadius, g);
                DrawRecursionStage(x, y - radius, newRadius, g);
                DrawRecursionStage(x + radius, y, newRadius, g);
                DrawRecursionStage(x, y + radius, newRadius, g);
            }
    
            private void DrawCircle(int x, int y, int radius, Graphics g)
            {
                g.DrawEllipse(Pens.Black, x - radius, y - radius, 2 * radius, 2 * radius);
            }
    
            private static bool IsRecursionDepthReached(int radius)
            {
                return radius < Math.Pow(factor, recursionDepth) * initialRadius;
            }
        }
    }
