`
private void InitImage(int size)
{
    openedImage = new Bitmap(size, size);
    closedImage = new Bitmap(size, size);
    using (Brush b = new SolidBrush(ArrowColor))
    {
        using (Graphics g = Graphics.FromImage(openedImage))
            g.FillPolygon(b, new[] { new Point(0, 0), new Point(size - 1, 0), new Point(size / 2, size - 1), });
        using (Graphics g = Graphics.FromImage(closedImage))
            g.FillPolygon(b, new[] { new Point(0, 0), new Point(size - 1, size / 2), new Point(0, size - 1), });
    }
}
`
