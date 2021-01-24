namespace BeziersLines 
{
    public partial class Form1 : Form
    {
        List<PointF> points;
        Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0), 3);
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // you can push some start Points here, [ new List<PointF>() {new PointF(0,0), new PointF(100,100), ...} ]
            points = new List<PointF>(); 
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            points.Add(e.Location);
            label1.Text = "Points count: " + points.Count().ToString();
            pictureBox1.Invalidate();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (points.Count() > 1)
            {
                var g = e.Graphics;
                if (!checkBox1.Checked)
                {
                    // Draw Lines
                    g.DrawLines(pen, points.ToArray());
                }
                else
                {
                    // Draw Bezier lines
                    var bezierPoints = points.Take(points.Count - (points.Count - 1) % 3).ToList();
                    g.DrawBeziers(pen, bezierPoints.ToArray());
                }
            }
        }
    }
}
[DEMO](https://imgur.com/a/L52tyea)
Use readable namings on English next time, its helps people to understand you better, and its a good practice to name it UNDERSTANDABLE for all code readers/users, not only for you.
P.S. 
var bezierPoints = points.Take(points.Count - (points.Count - 1) % 3).ToList();
This line computes the number of points in the array, based on MSD [arctile about DrawBeziers(Pen, PointF[])](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawbeziers?view=netframework-4.8) cpesificly that line: __"The number of points in the array should be a multiple of 3 plus 1, such as 4, 7, or 10."__
