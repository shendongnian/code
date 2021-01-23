    private string currentTool;
    private readonly List<Shape> shapes;
    private readonly List<Line> lines;
    private Line currentLine;
    private void Button1Click(object sender, EventArgs e)
    {
        currentTool = "img";
    }
    private void Button2Click(object sender, EventArgs e)
    {
        currentTool = "line";
    }
    private void PictureBox1MouseDown(object sender, MouseEventArgs e)
    {
        switch (currentTool)
        {
            case "img":
                shapes.Add(new Shape { Image = button1.Image, X = e.X, Y = e.Y });
                pictureBox1.Invalidate();
                break;
            case "line":
                foreach (Shape shape1 in shapes)
                    {
                        if (shape1.Test_int(e.X, e.Y))
                        {
                            currentLine = new Line { A = shape1 };
                        }
                    }
                    drawArea1.Invalidate();
            break;
        }
    }
    private void PictureBox1MouseUp(object sender, MouseEventArgs e)
    {
        switch (currentTool)
        {
            case "line":
                foreach (Shape shape1 in shapes)
                {
                    if (shape1.Test_int(e.X, e.Y))
                    {
                        
                        currentLine.B = shape1;
                        }
                    }
                    lines.Add(currentLine);
                    drawArea1.Invalidate();
               
                break;
        }
    }
    private void PictureBox1Paint(object sender, PaintEventArgs e)
    {
        foreach (var shape in shapes)
        {
            e.Graphics.DrawImage(shape.Image, shape.X, shape.Y);
        }
        foreach (var line in lines)
        {
            Pen p = new Pen(Color.Gray, 1);
            Pen p2 = new Pen(Color.Black, 5);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            p2.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p2.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            float x1 = line.A.X+line.A.Image.Width ;
            float y1 = line.A.Y+line.A.Image.Height/2;
            float x2 = line.B.X;
            float y2 = line.B.Y+line.B.Image.Height/2;
            double angle = Math.Atan2(y2 - y1, x2 - x1);
            e.Graphics.DrawLine(p, x1, y1, x2, y2);
            e.Graphics.DrawLine(p2, x2, y2, x2 + (float)(Math.Cos(angle)), y2 + (float)(Math.Sin(angle)));
        }
    }
