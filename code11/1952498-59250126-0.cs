csharp
private static Color[] GetColors(Image image)
{
    var bmp = new Bitmap(image);
    var colors = new Color[2];
    colors[0] = bmp.GetPixel(0, 0);
    for (int i = 0; i < bmp.Width; i++)
    {
        for (int j = 0; j < bmp.Height; j++)
        {
            Color c = bmp.GetPixel(i, j);
            if (c == colors[0]) continue;
            colors[1] = c;
            return colors;
        }   
    }
    return colors;
}
