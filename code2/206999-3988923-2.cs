    private List<Point> polygonPoints = new List<Point>();
    private void TestForm_MouseClick(object sender, MouseEventArgs e)
    {
        switch(e.Button)
        {
            case MouseButtons.Left:
                //draw line
                polygonPoints.Add(new Point(e.X, e.Y));
                if (polygonPoints.Count > 1)
                {
                    //draw line
                    this.DrawLine(polygonPoints[polygonPoints.Count - 2], polygonPoints[polygonPoints.Count - 1]);
                }
                break;
            case MouseButtons.Right:
                //finish polygon
                if (polygonPoints.Count > 2)
                {
                    //draw last line
                    this.DrawLine(polygonPoints[polygonPoints.Count - 1], polygonPoints[0]);
                    polygonPoints.Clear();
                }
                break;
        }
    }
    private void DrawLine(Point p1, Point p2)
    {
        Graphics G = this.CreateGraphics();
        G.DrawLine(Pens.Black, p1, p2);
    }
