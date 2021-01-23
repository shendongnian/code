    public class ImageController : Controller
    {
        public ActionResult Test()
        {
            var text = DateTime.Now.ToString();
            var font = new Font("Arial", 20, FontStyle.Regular);
            var angle = 233;
            SizeF textSize = GetEvenTextImageSize(text, font);
            SizeF imageSize;
            
            if (angle == 0)
                imageSize = textSize;
            else
                imageSize = GetRotatedTextImageSize(textSize, angle);
            using (var canvas = new Bitmap((int)imageSize.Width, (int)imageSize.Height))
            {
                using(var graphics = Graphics.FromImage(canvas))
                {
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                    SizeF textContainerSize = graphics.VisibleClipBounds.Size;
                    graphics.TranslateTransform(textContainerSize.Width / 2, textContainerSize.Height / 2);
                    graphics.RotateTransform(angle);
                    graphics.DrawString(text, font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
                }
                var stream = new MemoryStream();
                canvas.Save(stream, ImageFormat.Png);
                stream.Seek(0, SeekOrigin.Begin);
                return new FileStreamResult(stream, "image/png");
            }
        }
        private static SizeF GetEvenTextImageSize(string text, Font font)
        {
            using (var image = new Bitmap(1, 1, PixelFormat.Format32bppArgb))
            {
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    return graphics.MeasureString(text, font);
                }
            }
        }
        private static SizeF GetRotatedTextImageSize(SizeF fontSize, int angle)
        {
            // Source: http://www.codeproject.com/KB/graphics/rotateimage.aspx
            double theta = angle * Math.PI / 180.0;
            while (theta < 0.0)
                theta += 2 * Math.PI;
            double adjacentTop, oppositeTop;
            double adjacentBottom, oppositeBottom;
            if ((theta >= 0.0 && theta < Math.PI / 2.0) || (theta >= Math.PI && theta < (Math.PI + (Math.PI / 2.0))))
            {
                adjacentTop = Math.Abs(Math.Cos(theta)) * fontSize.Width;
                oppositeTop = Math.Abs(Math.Sin(theta)) * fontSize.Width;
                adjacentBottom = Math.Abs(Math.Cos(theta)) * fontSize.Height;
                oppositeBottom = Math.Abs(Math.Sin(theta)) * fontSize.Height;
            }
            else
            {
                adjacentTop = Math.Abs(Math.Sin(theta)) * fontSize.Height;
                oppositeTop = Math.Abs(Math.Cos(theta)) * fontSize.Height;
                adjacentBottom = Math.Abs(Math.Sin(theta)) * fontSize.Width;
                oppositeBottom = Math.Abs(Math.Cos(theta)) * fontSize.Width;
            }
            int nWidth = (int)Math.Ceiling(adjacentTop + oppositeBottom);
            int nHeight = (int)Math.Ceiling(adjacentBottom + oppositeTop);
            return new SizeF(nWidth, nHeight);
        }
    }
