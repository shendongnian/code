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
    
        // Paint ourselves with the specified Graphics object
        public void Draw(Graphics graphics)
        {
            using (Pen pen = new Pen(Color, PenWidth))
                graphics.DrawEllipse(pen, Rectangle);
        }
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
    
        // Definition of an Ellipse under construction
        class EllipseConstruction
        {
            public Point Origin;
            public Ellipse Ellipse;
        }
    
        // Storage for ellipse under construction.
        EllipseConstruction ellipseConstruction;
    
        // Random number generator Ellipse creation.
        private Random Rand = new Random();
    
        // These are the possible ellipse colors
        static readonly Color[] EllipseColors =
        {
            Color.Black,
            Color.White,
            Color.Red,
            Color.Green,
            Color.Blue,
            Color.Yellow,
            Color.Magenta,
            Color.Cyan,
        };
    
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Capture mouse until button up.
                Capture = true;
    
                // Create a new Ellipse object and record the [X, Y] origin of this click
                ellipseConstruction = new EllipseConstruction
                {
                    Origin = e.Location,
                    Ellipse = new Ellipse { Color = EllipseColors[Rand.Next(EllipseColors.Length)], PenWidth = Rand.Next(1, 6) },
                };
            }
    
            base.OnMouseDown(e);
        }
    
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // If the mouse is captured, the user is creating a new Ellipse so we update its rectangle with the mouse coordinates
            if (Capture)
                UpdateEllipseUnderConstruction(e.Location);
    
            base.OnMouseMove(e);
        }
    
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (Capture && e.Button == MouseButtons.Left)
            {
                // If the mouse is captured and it's the Left button being released, the user is
                //   done creating a new Ellipse.
    
                // Stop capturing the mouse.
                Capture = false;
    
                // Final update of the Ellipse under construction
                UpdateEllipseUnderConstruction(e.Location);
    
                // Add the new Ellipse to our list unless its width or height are zero which would result in a non-visible ellipse
                if (ellipseConstruction.Ellipse.Rectangle.Width > 0 && ellipseConstruction.Ellipse.Rectangle.Height > 0)
                    ellipses.Add(ellipseConstruction.Ellipse);
    
                // Since we are done constructing a new Ellipse, we don't need the construction object
                ellipseConstruction = null;
            }
    
            base.OnMouseUp(e);
        }
    
        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Allow Ellipse creation to be cancelled with the Escape key
            if (Capture && e.KeyData == Keys.Escape)
            {
                Capture = false; // End mouse capture
                ellipseConstruction = null; // Remove construction ellipse
                Invalidate(); // Notify operating system that we need to be repainted.
            }
    
            base.OnKeyDown(e);
        }
    
        private void UpdateEllipseUnderConstruction(Point point)
        {
            // Calculate new ellipse rectangle based on ellipseConstruction.Origin and point.
    
            Point origin = ellipseConstruction.Origin;
    
            int xRadius = Math.Abs(origin.X - point.X);
            int yRadius = Math.Abs(origin.Y - point.Y);
    
            // Make X and Y radii the same for a true circle unless the Shift key is held down
            if ((ModifierKeys & Keys.Shift) == 0)
                xRadius = yRadius = Math.Max(xRadius, yRadius);
    
            ellipseConstruction.Ellipse.Rectangle = new Rectangle(origin.X - xRadius, origin.Y - yRadius, xRadius * 2, yRadius * 2);
    
            Invalidate(); // Notify operating system that we need to be repainted.
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            // Paint the background since we specified ControlStyles.AllPaintingInWmPaint and ControlStyles.Opaque.
            e.Graphics.Clear(Color.SlateGray);
    
            // Paint the ellipses we have stored.
            foreach (Ellipse ellipse in ellipses)
                ellipse.Draw(e.Graphics);
    
            // If the user is creating a new ellipse paint it.
            if (ellipseConstruction != null)
                ellipseConstruction.Ellipse.Draw(e.Graphics);
    
            base.OnPaint(e);
        }
    }
