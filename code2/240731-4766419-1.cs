    public partial class Form1 : Form
    {
        private bool isMoving = false;
        private Point mouseDownPosition = Point.Empty;
        private Point mouseMovePosition = Point.Empty;
        private Dictionary<Point, Point> Circles = new Dictionary<Point, Point>();
        public Form1()
        {
            InitializeComponent();
            // 
            // pictureBox1
            //             
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(231, 235);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.Controls.Add(this.pictureBox1);
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Red);
            var g = e.Graphics;
            if (isMoving)
            {
                g.Clear(pictureBox1.BackColor);
                g.DrawEllipse(p, new Rectangle(mouseDownPosition, new Size(mouseMovePosition.X - mouseDownPosition.X, mouseMovePosition.Y - mouseDownPosition.Y)));
                foreach (var circle in Circles)
                {
                    g.DrawEllipse(p, new Rectangle(circle.Key, new Size(circle.Value.X - circle.Key.X, circle.Value.Y - circle.Key.Y)));
                }
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Cursor = Cursors.Cross;
            isMoving = true;
            mouseDownPosition = e.Location;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                mouseMovePosition = e.Location;
                pictureBox1.Invalidate();
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Cursor = Cursors.Default;
            if (isMoving)
            {
                Circles.Add(mouseDownPosition, mouseMovePosition);
            }
            isMoving = false;
        }
    }
