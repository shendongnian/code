    public ActionResult Image()     
        {
            var bitmap = GetBitmap(); // The method that returns List<Bitmap>
            var width = 0;
            var height = 0;
            foreach (var image in bitmap)
            {
                width += image.Width;
                height = image.Height > height
                    ? image.Height
                    : height;
            }
            var bitmap2 = new Bitmap(width, height);
            var g = Graphics.FromImage(bitmap2);
            var localWidth = 0;
            foreach (var image in bitmap)
            {
                g.DrawImage(image, localWidth, 0);
                localWidth += image.Width;
            }
           
            var ms = new MemoryStream();
            bitmap2.Save(ms, ImageFormat.Png);
             var   result = ms.ToArray();
             //string base64String = Convert.ToBase64String(result); 
             return File(result, "image/jpeg"); //Return as file result
            //return base64String;
        }
    //this method returns List<Bitmap>
    public List<Bitmap> GetBitmap()
        {
            var lstbitmap = new List<Bitmap>();
            var bitmap = new Bitmap(@"E:\My project\ProjectImage\ProjectImage\BmImage\1525244892128.JPEG");
            var bitmap2 = new Bitmap(@"E:\My project\ProjectImage\ProjectImage\BmImage\1525244892204.JPEG");
            var bitmap3 = new Bitmap(@"E:\My project\ProjectImage\ProjectImage\BmImage\3.jpg");
            lstbitmap.Add(bitmap);
            lstbitmap.Add(bitmap2);
            lstbitmap.Add(bitmap3);
            return lstbitmap;
        }
