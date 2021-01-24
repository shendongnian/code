    private int[,] matrix = new int[3, 3] {
        { 0, 1, 0 },
        { 0, 1, 0 },
        { 0, 1, 1 }
    };
    Size rectSize = new Size(30, 30);
    private void panel2_Paint(object sender, PaintEventArgs e)
    {
        int xPosition = 0;
        int yPosition = 0;
        using (var brush = new SolidBrush(Color.Tomato)) {
            for (var x = 0; x <= matrix.GetLength(0) - 1; x++)
            for (var y = 0; y <= matrix.GetLength(1) - 1; y++)
            {
                xPosition = y * rectSize.Width;
                yPosition = x * rectSize.Height;
                if (matrix[x, y] != 0) {
                    var rect = new Rectangle(new Point(xPosition, yPosition), rectSize);
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
        }
    }
