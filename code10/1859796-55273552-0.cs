        List<Image> ChartsToImages(List<Chart> charts)
        {
            var imageList = new List<Image>();            
            foreach (var c in charts)
            {
                using (var ms = new MemoryStream())
                {
                    c.SaveImage(ms, ChartImageFormat.Png);
                    var bmp = System.Drawing.Bitmap.FromStream(ms);
                    imageList.Add(bmp);
                }
            }
            return imageList;
        }
