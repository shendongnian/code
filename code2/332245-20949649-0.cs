        private void PhotoChooserTaskCompleted(object sender, PhotoResult e)
        {
            if (e.TaskResult != TaskResult.OK) return;
            var bmp = new BitmapImage();
            bmp.SetSource(e.ChosenPhoto);
            var scaledDownImage = AspectScale(bmp, 640, 480);
            MyImage.Source = scaledDownImage;
        }
        private BitmapImage AspectScale(BitmapImage img, int maxWidth, int maxHeigh)
        {
            double scaleRatio;
            if (img.PixelWidth > img.PixelHeight)
                scaleRatio = (maxWidth/(double) img.PixelWidth);
            else
                scaleRatio = (maxHeigh/(double) img.PixelHeight);
            var scaledWidth = img.PixelWidth * scaleRatio;
            var scaledHeight = img.PixelHeight * scaleRatio;
            using (var mem = new MemoryStream())
            {
                var wb = new WriteableBitmap(img);
                wb.SaveJpeg(mem, (int)scaledWidth, (int)scaledHeight, 0, 100);
                mem.Seek(0, SeekOrigin.Begin);
                var bn = new BitmapImage();
                bn.SetSource(mem);
                return bn;
            }
        }
