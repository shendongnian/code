using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
static public class ImageHelper
{
  static public Bitmap LoadBitmap(this string filename, double scale = 1)
  {
    var image = Image.FromFile(filename);
    return ResizeImage(image, (int)(image.Width * scale), (int)(image.Height * scale));
  }
  // ResizeImage code here
}
Usage:
    string filename = "path";
    var bitmap1 = filename.LoadBitmap(0.5);
    var bitmap2 = "path".LoadBitmap(0.5);
    var bitmap3 = ImageHelper.LoadBitmap("path", 0.5);
