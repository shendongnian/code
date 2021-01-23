        private string _currentTool;
        private readonly List<Shape> _shapes;
        private void Button1Click(object sender, EventArgs e)
        {
            _currentTool = "img";
        }
        private void PictureBox1MouseDown(object sender, MouseEventArgs e)
        {
            switch (_currentTool)
            {
                case "img":
                    _shapes.Add(new Shape {Image = button1.Image, X = e.X, Y = e.Y});
                    pictureBox1.Invalidate();
                    break;
            }
        }
        private void PictureBox1Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in _shapes)
            {
                e.Graphics.DrawImage(shape.Image, shape.X, shape.Y);
            }
        }
