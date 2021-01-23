    public class Line
    {
        public List<Point> Points = new List<Point>();
        public DrawLine(Pen pen, Grphics g)
        {
            for (int i = 0; i < Points.Count - 1; ++i)
                g.DrawLine(pen, Points[i], Points[i+1];
        }
    }
    private void PictureBoxOnMouseDown(Object sender, MouseEventArgs e)
    {
        if((e.Button & MouseButtons.Left) == MouseButtons.Left)
        {
            var newLine = new Line();
            newLine.Points.Add(e.Location);
            lines.Add(newLine);
        }
    }
    PictureBoxOnMouseMove(Object sender, MouseEventArgs e)
    {
        if((e.Button & MouseButtons.Left) == MouseButtons.Left)
        {
            lines[lines.Count-1].Points.Add(e.Location);
        }
    }
    private void PictureBoxOnPaint(Object sender, PaintEventArgs e)
    {
        using(var pen = new Pen(Color.Red, 3.0F))
        {
            foreach (var line in lines)
                DrawLine(pen, e.Graphics)
        }
     }
