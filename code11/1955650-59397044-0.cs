    public partial class Form1 : Form
    {
      int theAngle = 0;
      Pen pen2 = new Pen(Color.FromArgb(255, 68, 125, 255), 4);
      Pen pen3 = new Pen(Color.Green, 4);
      Pen smallPen = new Pen(Color.Black, 1);
      PointF center = new PointF(0, 0);
      Rectangle rectangle = new Rectangle(20, 20, 100, 30);
      Rectangle myRect2 = new Rectangle();
      Rectangle rotatedRect2 = new Rectangle();
      bool mouseBtnDown = false;
      Graphics gw;
      public Form1()
      {
        InitializeComponent();
        this.MouseDown += mouseDown;
        gw = this.CreateGraphics();
      }
      private void mouseDown(object sender, MouseEventArgs e)
      {
        if (e.Button == MouseButtons.Left)
        {
          if (rotatedRect2.Contains(e.Location))
            theAngle += 90;
          rotate();
        }
        if (e.Button == MouseButtons.Right)
        {
          //oval = false;
          //mouseBtnDown = false;
          theAngle = 0;
          rectangle.X = e.X - 50;
          rectangle.Y = e.Y - 15;
          rectangle.Width = 100;
          rectangle.Height = 30;
          center.X = rectangle.Left + (0.5f * rectangle.Width);
          center.Y = rectangle.Top + (0.5f * rectangle.Height);
          myRect2.Size = new Size(15, 15);
          myRect2.Location = new Point(rectangle.Left - 15, (rectangle.Top - (rectangle.Height / 2)) + 15);
          rotate();
          //drawstuff();
          // Invalidate();
        }
      }
      public void rotate()
      {
        var matrix = new Matrix();
        matrix.RotateAt(theAngle, center);
        gw.Transform = matrix;
        // Get the 4 corner points of myRect2.
        Point p1 = new Point(myRect2.X, myRect2.Y),
          p2 = new Point(myRect2.X + myRect2.Width, myRect2.Y),
          p3 = new Point(myRect2.X, myRect2.Y + myRect2.Height),
          p4 = new Point(myRect2.X + myRect2.Width, myRect2.Y + myRect2.Height);
        Point[] pts = new Point[] { p1, p2, p3, p4 };
        // Rotate the 4 points.
        gw.Transform.TransformPoints(pts);
        // Update rotatedRect2 with those rotated points.
        rotatedRect2.X = pts.Min(pt => pt.X);
        rotatedRect2.Y = pts.Min(pt => pt.Y);
        rotatedRect2.Width = pts.Max(pt => pt.X) - pts.Min(pt => pt.X);
        rotatedRect2.Height = pts.Max(pt => pt.Y) - pts.Min(pt => pt.Y);
        drawstuff();
      }
      public void drawstuff()
      {
        gw.SmoothingMode = SmoothingMode.AntiAlias; // Creates smooth lines.
        gw.DrawEllipse(pen2, rectangle);
        gw.DrawRectangle(smallPen, myRect2);
      }
    }
