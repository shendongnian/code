    private int[,] matrix = new int[3, 3] {
        { 0, 1, 0 },
        { 0, 1, 0 },
        { 0, 1, 1 }
    };
    private void panel2_Paint(object sender, PaintEventArgs e)
    {
        Size rectSize = new Size(30, 30);
        int xPosition = 0;
        int yPosition = 0;
        int xOffset = rectSize.Width;
        int yOffset = rectSize.Height;
        using (var brush = new SolidBrush(Color.Tomato)) {
            for (var x = 0; x <= matrix.GetLength(0) - 1; x++) {
                for (var y = 0; y <= matrix.GetLength(1) - 1; y++) {
                    xPosition = y * xOffset;
                    yPosition = x * yOffset;
                    if (matrix[x, y] != 0) {
                        var rect = new Rectangle(new Point(xPosition, yPosition), rectSize);
                        e.Graphics.FillRectangle(brush, rect);
                    }
                }
            }
        }
    }
