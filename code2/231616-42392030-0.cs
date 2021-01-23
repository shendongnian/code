    public partial class mainForm : Form
    {
        //Global variables for Moving a Borderless Form
        private bool dragging = false;
        private Point startPoint = new Point(0, 0); 
        
        public mainForm()
        {
            InitializeComponent();
        }
        private void mainForm_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }
        private void mainForm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        private void mainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }
    }
