    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    
    // Definition for our ellipse object.
    class Ellipse
    {
        public int PenWidth;
        public Color Color;
        public Rectangle Rectangle;
    }
    
    class Form1 : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    
        public Form1()
        {
            // Remove "flickering" from the repainting.
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }
    
        // Store all created ellipses so they can be rendered during the Paint event.
        List<Ellipse> ellipses = new List<Ellipse>();
    
        // Temporary storage for ellipse actively being created.
        private Point ellipseOrigin;
        private Rectangle ellipseRectangle;
    
        // Random number generator for ellipse colors.
        private Random Rand = new Random();
    
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Capture mouse until button up.
                Capture = true;
    
                // Store location of first click.
                ellipseOrigin = e.Location;
    
                UpdateEllipseRectangle(e.Location);
                Invalidate(); // Notify operating system that we need to be repainted.
            }
    
            base.OnMouseDown(e);
        }
    
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (Capture)
            {
                UpdateEllipseRectangle(e.Location);
                Invalidate(); // Notify operating system that we need to be repainted.
            }
    
            base.OnMouseMove(e);
        }
    
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Capture)
            {
                // Stop capturing the mouse.
                Capture = false;
    
                UpdateEllipseRectangle(e.Location);
                Invalidate(); // Notify operating system that we need to be repainted.
    
                // Add a new ellipse to our list unless it's width and height are both zero.
                // Note that using a random color like this could produce something too close to the background color. It's just a demo.
                if (ellipseRectangle.Width > 0 || ellipseRectangle.Height > 0)
                    ellipses.Add(new Ellipse { Rectangle = ellipseRectangle, Color = Color.FromArgb(255, Rand.Next(256), Rand.Next(256), Rand.Next(256)), PenWidth = Rand.Next(1, 6) });
            }
    
            base.OnMouseUp(e);
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            // Paint the background since we specified ControlStyles.AllPaintingInWmPaint and ControlStyles.Opaque.
            e.Graphics.FillRectangle(Brushes.SlateGray, e.ClipRectangle);
    
            // Paint the ellipses we have stored.
            foreach (Ellipse ellipse in ellipses)
                e.Graphics.DrawEllipse(new Pen(ellipse.Color, ellipse.PenWidth), ellipse.Rectangle);
    
            // If the mouse is captured, the user is creating a new ellipse. Paint it.
            if (Capture)
                e.Graphics.DrawEllipse(Pens.Brown, ellipseRectangle);
    
            base.OnPaint(e);
        }
    
        // Calculate new ellipse rectangle based on ellipseOrigin and point.
        private void UpdateEllipseRectangle(Point point)
        {
            int halfWidth = Math.Abs(ellipseOrigin.X - point.X);
            int halfHeight = Math.Abs(ellipseOrigin.Y - point.Y);
    
            // If you want a true circle, not any old ellipse, clamp it.
            halfWidth = halfHeight = Math.Max(halfWidth, halfHeight);
    
            ellipseRectangle = new Rectangle(ellipseOrigin.X - halfWidth, ellipseOrigin.Y - halfHeight, halfWidth * 2, halfHeight * 2);
        }
    }
