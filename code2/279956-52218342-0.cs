    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    public class ImageHelper
    {
    public Image CropImage(Image img)
    {
        int x = img.Width/2;
        int y = img.Height/2;
        int r = Math.Min(x, y);
        Bitmap tmp = null;
        tmp = new Bitmap(2 * r, 2 * r);
        using (Graphics g = Graphics.FromImage(tmp))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TranslateTransform(tmp.Width / 2, tmp.Height / 2);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0 - r, 0 - r, 2 * r, 2 * r);
            Region rg = new Region(gp);
            g.SetClip(rg, CombineMode.Replace);
            Bitmap bmp = new Bitmap(img);
            g.DrawImage(bmp, new Rectangle(-r, -r, 2 * r, 2 * r), new Rectangle(x - r, y - r, 2 * r, 2 * r), GraphicsUnit.Pixel);
        }
            return tmp;
    }
    public void SaveImage(Image img,string path,ImageFormat imageFormat)
    {
        img.Save(path, imageFormat);
    }
    }
   
