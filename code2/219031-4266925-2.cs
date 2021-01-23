    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Variable that will hold the point from which to draw the next line
        Point latestPoint;
        private void GainBox_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // Remember the location where the button was pressed
                latestPoint = e.Location;
            }
        }
        private void GainBox_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                using (Graphics g = GainBox.CreateGraphics())
                {
                    // Draw next line and...
                    g.DrawLine(Pens.Red, latestPoint, e.Location);
                    // ... Remember the location
                    latestPoint = e.Location;
                }
            }
        }
    }
