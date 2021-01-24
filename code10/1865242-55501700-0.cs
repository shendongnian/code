csharp
    public void imageUploader(Rectangle rectangle)
    {
        Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height, PixelFormat.Format32bppArgb);
        toGrayscale(bitmap);
        Graphics graphics = Graphics.FromImage(bitmap);
        graphics.CopyFromScreen(rectangle.Left, rectangle.Top, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
        bitmap.Save("proba.jpeg", ImageFormat.Jpeg);
        pictureBox1.Image = bitmap;
    }
You're converting each pixel of the bitmap to greyscale (oddly it looks like you're only grabbing the red channel) then copying from the screen, which overwrites your conversion. To fix it, all you should need to do is move the toGreyscale after you copy from the screen, like this:
csharp
    public void imageUploader(Rectangle rectangle)
    {
        Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height, PixelFormat.Format32bppArgb);
        Graphics graphics = Graphics.FromImage(bitmap);
        graphics.CopyFromScreen(rectangle.Left, rectangle.Top, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
        toGrayscale(bitmap);  # Moved after the copy from screen
        bitmap.Save("proba.jpeg", ImageFormat.Jpeg);
        pictureBox1.Image = bitmap;
    }
This should fix the issue.
