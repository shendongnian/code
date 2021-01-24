    class Box
    {
        public Color color { get; set; } = Color.Red;
        // Note: Conventionally, property names begin with a capital letter.
        /// <summary>
        /// Draw this block to the given graphics context.
        /// </summary>
        /// <param name="g">The graphics context to draw to.</param>
        /// <param name="x">X-coordinate of the block within the graphics context.</param>
        /// <param name="y">Y-coordinate of the block within the graphics context.</param>
        /// <param name="width">Width of the area in which to draw the block.</param>
        /// <param name="height">Height of the area in which to draw the block.</param>
        public void DrawTo(Graphics g, int x, int y, int width, int height)
        {
            // Fill in the color of this block:
            Brush brush = new SolidBrush(color);     // fill style, color etc.
            g.FillRectangle(brush, x, y, width, height);
            // Black outline:
            Pen pen = new Pen(Color.Black);       // line style, color, etc.
            g.DrawRectangle(pen, x, y, width, height);
            // look up the documentation of the System.Drawing.Graphics class for other methods for drawing.
        }
    }
