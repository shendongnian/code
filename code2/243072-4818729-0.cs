      public partial class Form1 : Form
    {
        // Create list 
        List<Ball> _balls = new List<Ball>();
        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint; 
            this.MouseMove += Form1_MouseMove;
            this.MouseClick += Form1_MouseClick;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Point local = this.PointToClient(Cursor.Position);
            e.Graphics.FillEllipse(Brushes.Red, local.X , local.Y , 20, 20);
            // Paint each stored ball
            foreach(var ball in _balls) {
               // paint ball
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Invalidate();
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Random random = new Random();
            Ball myBall = new Ball(random.Next(1, 5));
            // Store ball, and refresh screen
            _balls.Add(myBall);
            Invalidate()
        }      
 
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
