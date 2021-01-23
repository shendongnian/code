    using System;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace CPS
    {
        class gradientGrid : DataGridView
        {
    
            protected override void PaintBackground(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle gridBounds)
            {
                base.PaintBackground(graphics, clipBounds, gridBounds);
    
                System.Drawing.Drawing2D.LinearGradientBrush b = new System.Drawing.Drawing2D.LinearGradientBrush(clipBounds, Color.CadetBlue, Color.AntiqueWhite, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
                graphics.FillRectangle(b, clipBounds);
            }
        }
    }
