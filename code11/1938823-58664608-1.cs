using System.Drawing;
static public class ImageHelper
{
  static Bitmap LoadBitmap(this string filename, double scale = 1)
  {
    var image = Image.FromFile(filename);
    return ResizeImage(image, image.Width * scale, image.Height * scale);
  }
  //ResizeImage code here
}
Usage:
    var bitmap1 = "path".LoadBitmap(0.5);
    string filename = "path";
    var bitmap2 = filename.LoadBitmap(0.5);
    var bitmap3 = ImageHelper.LoadBitmap("path", 0.5);
