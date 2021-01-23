    private string _currentTool;
    private readonly List<Shape> _shapes;
    private readonly List<Line> _lines;
    private Line _currentLine;
    private void Button1Click(object sender, EventArgs e)
    {
        _currentTool = "img";
    }
    private void Button2Click(object sender, EventArgs e)
    {
        _currentTool = "line";
    }
    private void PictureBox1MouseDown(object sender, MouseEventArgs e)
    {
        switch (_currentTool)
        {
            case "img":
                _shapes.Add(new Shape { Image = button1.Image, X = e.X, Y = e.Y });
                pictureBox1.Invalidate();
                break;
            case "line":
                    var selectedShapes = _shapes.Where(shape => (shape.X - 10 < e.X) && (e.X < shape.X + 10) &&
                                                               (shape.Y - 10 < e.Y) && (e.Y < shape.Y + 10));
                    if (selectedShapes.Count() > 0)
                    {
                        var selectedShape = selectedShapes.First();
                        _currentLine = new Line {A = selectedShape};
                        pictureBox1.Invalidate();
                    }
                break;
        }
    }
    private void PictureBox1MouseUp(object sender, MouseEventArgs e)
    {
        switch (_currentTool)
        {
            case "line":
                    var selectedShapes = _shapes.Where(shape => (shape.X - 10 < e.X) && (e.X < shape.X + 10) &&
                                                               (shape.Y - 10 < e.Y) && (e.Y < shape.Y + 10));
                    if (selectedShapes.Count() > 0)
                    {
                        var selectedShape = selectedShapes.First();
                        _currentLine.B = selectedShape;
                        _lines.Add(_currentTool);
                        pictureBox1.Invalidate();
                    }
                break;
        }
    }
    private void PictureBox1Paint(object sender, PaintEventArgs e)
    {
        foreach (var shape in _shapes)
        {
            e.Graphics.DrawImage(shape.Image, shape.X, shape.Y);
        }
        foreach (var line in _lines)
        {
            e.Graphics.DrawLine(new Pen(Color.Black), line.A.X, line.A.Y, line.B.X, line.B.Y);
        }
    }
