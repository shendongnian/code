    public partial class Form1 : Form
    {
        private readonly Image transparentImg; // The transparent image
        private bool isMoving = false;         // true while dragging the image
        private Point movingPicturePosition = new Point(80, 20);   // the position of the moving image
        private Point offset;   // mouse position inside the moving image while dragging
        public Form1()
        {
            InitializeComponent();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(231, 235);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.Controls.Add(this.pictureBox1);
            transparentImg = Image.FromFile("..\\..\\Resources\\transp.png");
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.DrawImageUnscaled(transparentImg, new Point(20, 20));      // image1
            g.DrawImageUnscaled(transparentImg, new Point(140, 20));     // image2
            g.DrawImageUnscaled(transparentImg, movingPicturePosition);  // image3
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            var r = new Rectangle(movingPicturePosition, transparentImg.Size);
            if (r.Contains(e.Location))
            {
                isMoving = true;
                offset = new Point(movingPicturePosition.X - e.X, movingPicturePosition.Y - e.Y);
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                movingPicturePosition = e.Location;
                movingPicturePosition.Offset(offset);
                pictureBox1.Invalidate();
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;
        }
    }
