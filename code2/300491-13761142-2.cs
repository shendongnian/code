    public class Lines
    {
        public Point startPoint = new Point();
        public Point endPoint = new Point();
    }  
    Lines l = new Lines();
    List<Lines> allLines = new List<Lines>();
    
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //collect endPoint when mouse moved
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                l.endPoint = e.Location;
                //Line completed
                allLines.Add(l);
                this.pictureBox1.Invalidate();
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //collect startPoint when left mouse clicked
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                l = new Lines();
                l.startPoint = e.Location;
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var aLine in allLines)
            {
                e.Graphics.DrawLine(Pens.Blue, aLine.startPoint, aLine.endPoint);
            }
        }
