using System.Drawing;
static public BitmapHelper
{
  static Bitmap LoadBitmap(this string filename, double scale = 1)
  {
    var image = Image.FromFile(filename);
    var bitmap = ResizeImage(image, image.Width * scale, image.Height * scale);
  }
}
Usage:
    var bitmap = "path".LoadBitmap(0.5);
